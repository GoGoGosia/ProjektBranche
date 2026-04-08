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

        private void button3_Click(object sender, EventArgs e)
        {
            onlyGreen();
        }

        public void onlyGreen()
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
                    Color pixelColor = bitmap.GetPixel(x, y);

                    if (!(pixelColor.G > pixelColor.R && pixelColor.G > pixelColor.B))
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }

            pictureBox1.Image = bitmap;
        }
    }
}
