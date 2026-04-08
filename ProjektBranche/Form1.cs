namespace ProjektBranche
{
    public partial class Form1 : Form
    {
        Bitmap Image;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadImage();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki BMP (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = Image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas wczytywania obrazu: " + ex.Message);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rotateImage90()
        {
            if (pictureBox1.Image == null) return;
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bitmap;
        }
        private void rotateImage180()
        {
            if (pictureBox1.Image == null) return;
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image = bitmap;
        }
        private void rotateImage270()
        {
            if (pictureBox1.Image == null) return;
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Wczytaj obraz.");
                return;
            }
            if (radioButton1.Checked)
            {
                rotateImage90();
            }
            else if (radioButton2.Checked)
            {
                rotateImage180();
            }
            else if (radioButton3.Checked)
            {
                rotateImage270();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            invertColors();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Wczytaj obraz.");
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            pictureBox1.Image = bitmap;
        }

        private void invertColors()
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Wczytaj obraz.");
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    Color inverted = Color.FromArgb(pixel.A, 255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    bitmap.SetPixel(x, y, inverted);
                }
            }

            pictureBox1.Image = bitmap;
        }
    }
}
