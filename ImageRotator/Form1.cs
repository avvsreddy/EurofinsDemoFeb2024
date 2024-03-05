using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRotator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // rotate images the save
            var imageFiles = Directory.GetFiles(@"E:\Demos\EurofinsDemoFeb2024\ImageRotator\images");

            //Bitmap bitmap = null;

            //foreach (var imageFile in imageFiles)
            Parallel.ForEach(imageFiles, imageFile =>
            {
                Bitmap bitmap = new Bitmap(imageFile);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                FileInfo fileInfo = new FileInfo(imageFile);
                bitmap.Save(@"E:\Demos\EurofinsDemoFeb2024\ImageRotator\rotated\" + fileInfo.Name);
            });

        }
    }
}
