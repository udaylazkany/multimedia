namespace project_1
{
    public partial class Form1 : Form
    {
        private Image originalImage;

        convert_class convert_color_to = new convert_class();

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                originalImage = (Image)pictureBox1.Image.Clone();   // ✔ الآن صحيح
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // لا تعمل Clone إذا لم تكن هناك صورة أصلًا
                if (pictureBox1.Image != null)
                    originalImage = (Image)pictureBox1.Image.Clone();

                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                pictureBox1.Image = Image.FromFile(files[0]);
                originalImage = (Image)pictureBox1.Image.Clone();   // ✔ الآن الصورة موجودة
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void convertToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.rgbcolor(pictureBox1);
        }

        private void cMYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.cmykcolor(pictureBox1);
        }

        private void hSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.hsvcolor(pictureBox1);
        }

        private void yUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.YUVcolor(pictureBox1);
        }

        private void lABToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.LABcolor(pictureBox1);
        }

        private void yCBCRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (originalImage != null)
                pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.yCbCrcolor(pictureBox1);
        }
    }
}
