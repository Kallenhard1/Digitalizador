using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using WiaDotNet;
using WIA;
using Tesseract;
using SautinSoft.Document;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace ScanEstractSystem
{
    public partial class Digitalize : Form
    {
        public Digitalize()
        {
            InitializeComponent();
        }

        private void Digitalizar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                Digitalizar.Text = folder.SelectedPath;
                string inpFile = Digitalizar.Text + @"\test1.png";
                string outFile = "Result.pdf";

                ImageLoadOptions lo = new ImageLoadOptions();
                lo.OCROptions.OCRMode = OCRMode.Enabled;
                lo.OCROptions.OCRMode = OCRMode.Enabled;

                lo.OCROptions.Method = PerformOCRTesseract;
                DocumentCore dc = DocumentCore.Load(inpFile, lo);

                foreach (Run r in dc.GetChildElements(true, ElementType.Run))
                {
                    r.CharacterFormat.FontColor = SautinSoft.Document.Color.Black;
                    r.CharacterFormat.Scaling = 100;
                    r.CharacterFormat.Spacing = 0;
                }

                dc.Save(outFile);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
        }

        public static byte[] PerformOCRTesseract(byte[] image)
        {
            string tesseractLanguages = "por";
            string tesseractData = Path.GetFullPath(@"..\..\..\tessdata\");

            string tempFile = Path.Combine(tesseractData, Path.GetRandomFileName());

            try
            {
                using (Tesseract.IResultRenderer renderer = Tesseract.PdfResultRenderer.CreatePdfRenderer(tempFile, tesseractData, true))
                {
                    using (renderer.BeginDocument("Serachablepdf"))
                    {
                        using (Tesseract.TesseractEngine engine = new Tesseract.TesseractEngine(tesseractData, tesseractLanguages, Tesseract.EngineMode.Default))
                        {
                            engine.DefaultPageSegMode = Tesseract.PageSegMode.Auto;
                            using (MemoryStream msImg = new MemoryStream(image))
                            {
                                System.Drawing.Image imgWithText = System.Drawing.Image.FromStream(msImg);
                                for (int i = 0; i < imgWithText.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page); i++)
                                {
                                    imgWithText.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, i);
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        imgWithText.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                        byte[] imgBytes = ms.ToArray();
                                        using (Tesseract.Pix img = Tesseract.Pix.LoadFromMemory(imgBytes))
                                        {
                                            using (var page = engine.Process(img, "Serachablepdf"))
                                            {
                                                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                                                //saveFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
                                                //saveFileDialog.Title = "Salvar PDF";

                                                //if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                                //{
                                                //    string text = page.GetText();
                                                //}

                                                //iTextSharp.text.Document doc = new iTextSharp.text.Document();
                                                //string pdfFilePath = saveFileDialog.FileName;

                                                //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));

                                                //MessageBox.Show("Arquivo PDF salvo com sucesso!");

                                                string text = page.GetText();

                                                renderer.AddPage(page);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return File.ReadAllBytes(tempFile + ".pdf");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Porfavor, tenha certeza de colocar o caminh certo da sua pasta (*.traineddata), \"tessdata\"");
                Console.WriteLine("Os arquivos de linguagem podem ser encontrados aqui: https://github.com/tesseract-ocr/tessdata_fast");
                Console.ReadKey();
                throw new Exception("Erro Tesseract: " + e.Message);
            }
            finally
            {
                if (File.Exists(tempFile + ".pdf"))
                    File.Delete(tempFile + ".pdf");
            }
        }

        private void Scanner_Click(object sender, EventArgs e)
        {
            // Detecta scanners instalados
            var deviceManager = new DeviceManager();
            if (deviceManager.DeviceInfos.Count == 0)
            {
                MessageBox.Show("Nenhum scanner detectado.");
                return;
            }

            // Seleciona o primeiro scanner detectado (você pode adicionar lógica para escolher um scanner específico)
            var scanner = deviceManager.DeviceInfos[1].Connect();

            // Configura as propriedades do scanner
            var scannerItem = scanner.Items[1];
            scannerItem.Properties["6146"].set_Value(1); // Configura o tipo de cor (1 = Color, 2 = Grayscale, 4 = Black & White)
            scannerItem.Properties["6147"].set_Value(300); // Configura a resolução (dpi)

            // O codigo abaixo foi comentado porque não tenho um scanner para testar sua funcionalidade
            // Digitaliza o documento
            //var imageFile = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatPNG);

            // Salva a imagem em um arquivo temporário
            //string tempFilePath = "caminho_para_o_arquivo_temporario.tif";
            //imageFile.SaveFile(tempFilePath);

            //MessageBox.Show("Documento digitalizado com sucesso.");
        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            // Configura o OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
            openFileDialog.Title = "Abrir Arquivo PDF";

            // Exibe o diálogo e verifica se o usuário selecionou um arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho completo do arquivo PDF selecionado
                string caminhoDoArquivoPDF = openFileDialog.FileName;

                // Abre o arquivo PDF com o visualizador padrão
                try
                {
                    // Precisei setar o Process dessa maneira ou não executava o PDF Reader da Adobe
                    Process.Start(new ProcessStartInfo(caminhoDoArquivoPDF) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o arquivo PDF: {ex.Message}");
                }
            }
        }
    }
}

