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

    }
}
