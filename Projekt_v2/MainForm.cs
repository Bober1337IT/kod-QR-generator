using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using ZXing;
using ZXing.QrCode.Internal;

namespace Projekt_v2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            picQRCode.Paint += picQRCode_Paint;
        }


        private Bitmap qrCodeImage;

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Proszę wprowadzić tekst do zakodowania w QR!");
                return;
            }

            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCoder.QRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(20);

                Bitmap scaledQRCode = new Bitmap(qrCodeImage, new Size(250, 250));

                picQRCode.Image = scaledQRCode;
                picQRCode.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void picQRCode_Paint(object sender, PaintEventArgs e)
        {
            if (qrCodeImage != null)
            {
                e.Graphics.DrawImage(qrCodeImage, 0, 0, 250, 250);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, 0, 0, 250, 250);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (qrCodeImage == null)
            {
                MessageBox.Show("Brak obrazu QR do zapisania.");
                return;
            }

            SaveData saveDataForm = new SaveData(txtInput.Text, qrCodeImage);
            saveDataForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            this.Close();
        }

        private void btnOpenRandom_Click(object sender, EventArgs e)
        {
            RandomStringForm randomStringForm = new RandomStringForm();
            randomStringForm.ShowDialog();
            string saveInput = txtInput.Text;
            txtInput.Text = randomStringForm.GeneratedText;
            if(txtInput.Text != "") { 
            this.btnGenerate_Click(sender, e);
            }
            else
            {
                txtInput.Text = saveInput;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki PNG (*.png)|*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap loadedQRCode = new Bitmap(openFileDialog.FileName);
                    Bitmap scaledQRCode = new Bitmap(loadedQRCode, new Size(250, 250));

                    picQRCode.Image = scaledQRCode;
                    picQRCode.Invalidate();

                    string decodedText = DecodeQRCode(scaledQRCode);
                    txtInput.Text = decodedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd przy wczytywaniu lub dekodowaniu QR: {ex.Message}");
                }
            }
        }

        private string DecodeQRCode(Bitmap qrCodeImage)
        {
            try
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(qrCodeImage);

                if (result != null)
                {
                    return result.Text;
                }
                else
                {
                    return "Nie udało się odczytać QR!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dekodowania QR: {ex.Message}");
                return string.Empty;
            }
        }

        private void btnOpenWeb_Click(object sender, EventArgs e)
        {
            string url = txtInput.Text;

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                MessageBox.Show("Wymagany protokół http lub https");
                return;
            }

            FormWebBrowser formWebBrowser = new FormWebBrowser(url);
            formWebBrowser.ShowDialog();
        }
    }
}
