using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_v2
{
    public partial class SaveData : Form
    {
        private string qrText;
        private Bitmap qrImage;

        public SaveData(string qrText, Bitmap qrImage)
        {
            InitializeComponent();
            this.qrText = qrText;
            this.qrImage = qrImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            this.Close();
        }

        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Pliki tekstowe (*.txt)|*.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "Link.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, qrText);
                    MessageBox.Show("Link zapisany pomyślnie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd przy zapisywaniu pliku: {ex.Message}");
                }
            }
            Thread.Sleep(500);
            this.Close();
        }

        private void btnSavePng_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Pliki PNG (*.png)|*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "QRcode.png"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    qrImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Obraz QR zapisany pomyślnie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd przy zapisywaniu pliku: {ex.Message}");
                }
            }
            Thread.Sleep(500);
            this.Close();
        }
    }
}
