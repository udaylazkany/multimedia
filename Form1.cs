using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace project_1
{
    public partial class Form1 : Form
    {
        // ========== الكلاسات الجديدة ==========
        ImageLoader loader = new ImageLoader();
        ColorConverter converter = new ColorConverter();
        ColorAdjuster adjust = new ColorAdjuster();
        ColorSystemShapes shapes = new ColorSystemShapes();


        // ========== متغيرات الفورم ==========
        Bitmap newOriginal;
        Bitmap editedImage;
        Bitmap rgbEdited;
        Bitmap hsvEdited;
        Bitmap yuvEdited;
        Bitmap labEdited;
        Bitmap cmykEdited;
        Bitmap ycbcrEdited;


        string currentSystem = "";
        string selectedChannel = "";

        int r = 0, g = 0, b = 0;
        int h = 0, s = 0, v = 0;
        int y = 0, u = 0, v2 = 0;
        int L = 0, A = 0, B = 0;
        int y3 = 0, cb = 0, cr = 0;
        int c = 0, m = 0, yk = 0, k = 0;

        bool editPanelVisible = false;
        bool isSystemViewShown = false;
        Image lastShownImage;

        public Form1()
        {
            InitializeComponent();

            trackBar1.Visible = false;
            comboChannels.Visible = false;

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            trackBar1.Scroll += trackBar1_Scroll;
            comboChannels.SelectedIndexChanged += comboChannels_SelectedIndexChanged;
        }

        // ============================
        // تحميل صورة
        // ============================

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var img = loader.LoadFromDialog(openFileDialog1);
            if (img != null)
            {
                pictureBox1.Image = img;
                newOriginal = new Bitmap(img);
                editedImage = new Bitmap(img);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                var img = loader.LoadFromPath(files[0]);
                pictureBox1.Image = img;
                newOriginal = new Bitmap(img);
                editedImage = new Bitmap(img);
            }
        }


        // ============================
        // التحويل بين الأنظمة اللونية
        // ============================

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "RGB";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (rgbEdited != null)
            {
                pictureBox1.Image = (Bitmap)rgbEdited.Clone();
                newOriginal = (Bitmap)rgbEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToRGB(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("Red", "Green", "Blue");
        }


        private void cMYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "CMYK";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (cmykEdited != null)
            {
                pictureBox1.Image = (Bitmap)cmykEdited.Clone();
                newOriginal = (Bitmap)cmykEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToCMYK(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("Cyan", "Magenta", "Yellow", "Black");
        }


        private void hSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "HSV";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (hsvEdited != null)
            {
                pictureBox1.Image = (Bitmap)hsvEdited.Clone();
                newOriginal = (Bitmap)hsvEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToHSV(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("Hue", "Saturation", "Value");
        }


        private void yUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "YUV";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (yuvEdited != null)
            {
                pictureBox1.Image = (Bitmap)yuvEdited.Clone();
                newOriginal = (Bitmap)yuvEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToYUV(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("Y", "U", "V");
        }


        private void lABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "LAB";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (labEdited != null)
            {
                pictureBox1.Image = (Bitmap)labEdited.Clone();
                newOriginal = (Bitmap)labEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToLAB(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("L", "A", "B");
        }

        private void yCBCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSystem = "YCbCr";
            isSystemViewShown = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";

            if (ycbcrEdited != null)
            {
                pictureBox1.Image = (Bitmap)ycbcrEdited.Clone();
                newOriginal = (Bitmap)ycbcrEdited.Clone();
            }
            else
            {
                pictureBox1.Image = converter.ToYCbCr(loader.OriginalImage);
                newOriginal = new Bitmap(pictureBox1.Image);
            }

            editedImage = new Bitmap(newOriginal);
            SetupChannels("Y", "Cb", "Cr");
        }

        private void UpdateTrackBarValue()
        {
            switch (currentSystem)
            {
                case "RGB":
                    if (selectedChannel == "Red") trackBar1.Value = r;
                    if (selectedChannel == "Green") trackBar1.Value = g;
                    if (selectedChannel == "Blue") trackBar1.Value = b;
                    break;

                case "CMYK":
                    if (selectedChannel == "Cyan") trackBar1.Value = c;
                    if (selectedChannel == "Magenta") trackBar1.Value = m;
                    if (selectedChannel == "Yellow") trackBar1.Value = yk;
                    if (selectedChannel == "Black") trackBar1.Value = k;
                    break;

                case "HSV":
                    if (selectedChannel == "Hue") trackBar1.Value = h;
                    if (selectedChannel == "Saturation") trackBar1.Value = s;
                    if (selectedChannel == "Value") trackBar1.Value = v;
                    break;

                case "YUV":
                    if (selectedChannel == "Y") trackBar1.Value = y;
                    if (selectedChannel == "U") trackBar1.Value = u;
                    if (selectedChannel == "V") trackBar1.Value = v2;
                    break;

                case "LAB":
                    if (selectedChannel == "L") trackBar1.Value = L;
                    if (selectedChannel == "A") trackBar1.Value = A;
                    if (selectedChannel == "B") trackBar1.Value = B;
                    break;

                case "YCbCr":
                    if (selectedChannel == "Y") trackBar1.Value = y3;
                    if (selectedChannel == "Cb") trackBar1.Value = cb;
                    if (selectedChannel == "Cr") trackBar1.Value = cr;
                    break;
            }
        }

        private void SetupChannels(params string[] channels)
        {
            comboChannels.Items.Clear();
            comboChannels.Items.AddRange(channels);
            comboChannels.SelectedIndex = 0;
            UpdateTrackBarValue();

            newOriginal = new Bitmap(pictureBox1.Image);
            editedImage = new Bitmap(newOriginal);
        }

        // ============================
        // اختيار القناة
        // ============================

        private void comboChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedChannel = comboChannels.SelectedItem.ToString();
            UpdateTrackBarValue();

        }

        // ============================
        // التعديل عبر TrackBar
        // ============================

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (newOriginal == null) return;

            int v = trackBar1.Value;

            switch (currentSystem)
            {
                case "RGB":
                    if (selectedChannel == "Red") r = v;
                    if (selectedChannel == "Green") g = v;
                    if (selectedChannel == "Blue") b = v;

                    editedImage = adjust.AdjustRGB(newOriginal, r, g, b);
                    rgbEdited = (Bitmap)editedImage.Clone();
                    break;

                case "CMYK":
                    if (selectedChannel == "Cyan") c = v;
                    if (selectedChannel == "Magenta") m = v;
                    if (selectedChannel == "Yellow") yk = v;
                    if (selectedChannel == "Black") k = v;

                    editedImage = adjust.AdjustCMYK(newOriginal, c, m, yk, k);
                    cmykEdited = (Bitmap)editedImage.Clone();
                    break;

                case "HSV":
                    if (selectedChannel == "Hue") h = v;
                    if (selectedChannel == "Saturation") s = v;
                    if (selectedChannel == "Value") this.v = v;

                    editedImage = adjust.AdjustHSV(newOriginal, h, s, this.v);
                    hsvEdited = (Bitmap)editedImage.Clone();
                    break;

                case "YUV":
                    if (selectedChannel == "Y") y = v;
                    if (selectedChannel == "U") u = v;
                    if (selectedChannel == "V") v2 = v;

                    editedImage = adjust.AdjustYUV(newOriginal, y, u, v2);
                    yuvEdited = (Bitmap)editedImage.Clone();
                    break;

                case "LAB":
                    if (selectedChannel == "L") L = v;
                    if (selectedChannel == "A") A = v;
                    if (selectedChannel == "B") B = v;

                    editedImage = adjust.AdjustLAB(newOriginal, L, A, B);
                    labEdited = (Bitmap)editedImage.Clone();
                    break;

                case "YCbCr":
                    if (selectedChannel == "Y") y3 = v;
                    if (selectedChannel == "Cb") cb = v;
                    if (selectedChannel == "Cr") cr = v;

                    editedImage = adjust.AdjustYCbCr(newOriginal, y3, cb, cr);
                    ycbcrEdited = (Bitmap)editedImage.Clone();
                    break;
            }

            pictureBox1.Image = editedImage;
        }


        // ============================
        // Reset
        // ============================

        private void resetColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader.OriginalImage == null) return;

            pictureBox1.Image = (Image)loader.OriginalImage.Clone();
            newOriginal = new Bitmap(pictureBox1.Image);
            editedImage = new Bitmap(newOriginal);

            r = g = b = 0;
            h = s = v = 0;
            y = u = v2 = 0;
            L = A = B = 0;
            y3 = cb = cr = 0;
            c = m = yk = k = 0;

            trackBar1.Value = 0;

            if (comboChannels.Items.Count > 0)
                comboChannels.SelectedIndex = 0;
        }

        // ============================
        // About Image
        // ============================

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader.OriginalImage == null)
            {
                MessageBox.Show("لا توجد صورة معروضة حالياً.");
                return;
            }

            string filePath = openFileDialog1.FileName;
            FileInfo info = new FileInfo(filePath);
            Bitmap bmp = new Bitmap(loader.OriginalImage);

            string details =
                 $"اسم الملف: {info.Name}\n" +
        $"المسار الكامل: {info.FullName}\n" +
        $"الحجم: {info.Length / 1024.0:F2} KB\n" +
        $"العرض: {bmp.Width} بكسل\n" +
        $"الارتفاع: {bmp.Height} بكسل\n" +
        $"صيغة الصورة: {bmp.RawFormat}\n" +
        $"Pixel Format: {bmp.PixelFormat}\n" +
        $"Bits Per Pixel: {Image.GetPixelFormatSize(bmp.PixelFormat)}\n" +
        $"Has Alpha: {Image.IsAlphaPixelFormat(bmp.PixelFormat)}\n" +
        $"DPI X: {bmp.HorizontalResolution}\n" +
        $"DPI Y: {bmp.VerticalResolution}\n" +
        $"عدد الألوان النظرية: {Math.Pow(2, Image.GetPixelFormatSize(bmp.PixelFormat))}\n";
            MessageBox.Show(details, "About Image");
        }

        // ============================
        // حفظ الصورة
        // ============================

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePicture save = new SavePicture();
            save.Save(editedImage);
        }

        // ============================
        // إظهار/إخفاء أدوات التعديل
        // ============================

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPanelVisible = !editPanelVisible;
            trackBar1.Visible = editPanelVisible;
            comboChannels.Visible = editPanelVisible;
        }

        private void viewSystemColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // إذا كنا الآن في وضع "عرض الشكل" ونريد الرجوع للصورة
            if (isSystemViewShown)
            {
                if (lastShownImage != null)
                    pictureBox1.Image = (Image)lastShownImage.Clone();

                isSystemViewShown = false;
                viewSystemColorToolStripMenuItem.Text = "View System Color";
                return;
            }

            // هنا نحن في وضع الصورة، ونريد الانتقال لعرض الشكل
            // نحفظ "آخر صورة معروضة" (قد تكون أصلية أو معدّلة)
            if (pictureBox1.Image != null)
                lastShownImage = (Image)pictureBox1.Image.Clone();
            else
                lastShownImage = null;

            Bitmap bmp = null;

            switch (currentSystem)
            {
                case "RGB": bmp = shapes.DrawRGBCube(); break;
                case "CMYK": bmp = shapes.DrawCMYKCube(); break;
                case "HSV": bmp = shapes.DrawHSVShape(); break;
                case "YUV": bmp = shapes.DrawYUVShape(); break;
                case "LAB": bmp = shapes.DrawLABShape(); break;
                case "YCbCr": bmp = shapes.DrawYCbCrShape(); break;
            }

            if (bmp != null)
            {
                pictureBox1.Image = bmp;
                isSystemViewShown = true;
                viewSystemColorToolStripMenuItem.Text = "View Picture";
            }
        }

    }
}
