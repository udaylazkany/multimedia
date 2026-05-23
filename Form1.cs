using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace project_1
{
    public partial class Form1 : Form
    {
        // ========== الكلاسات الجديدة ==========
        ImageLoader loader = new ImageLoader();
        ColorConverter converter = new ColorConverter();
        ColorAdjuster adjust = new ColorAdjuster();
        ColorSystemShapes shapes = new ColorSystemShapes();
        ColorReducer reducer = new ColorReducer();


        private Label labelColorInfo;

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

        Image lastShownImage;
        bool isUpdatingTrackBar = false;
        bool is3D = false;
        float rotationX = 0;
        float rotationY = 0;
        float zoom = 1.0f;
        bool dragging = false;
        Point lastPoint;
        float zoom2D = 1.0f;
        int offsetX2D = 0;
        int offsetY2D = 0;

        bool colorReductionMode = false;



        public Form1()
        {
            InitializeComponent();
            pictureBox3.Visible = false;
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.BackColor = Color.Black;
            pictureBox3.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            pictureBox3.MouseUp += pictureBox3_MouseUp;
            pictureBox3.MouseMove += pictureBox3_MouseMove;
            pictureBox3.MouseWheel += pictureBox3_MouseWheel;
            pictureBox3.Paint += pictureBox3_Paint;


            trackBar1.Visible = false;
            comboChannels.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Size = pictureBox1.Size;
            pictureBox2.Location = pictureBox1.Location;
            labelColorInfo = new Label();
            labelColorInfo.Dock = DockStyle.Bottom;
            labelColorInfo.Height = 80;
            labelColorInfo.AutoSize = false;
            labelColorInfo.Font = new Font("Segoe UI", 10);
            labelColorInfo.BackColor = Color.WhiteSmoke;
            labelColorInfo.ForeColor = Color.Black;
            labelColorInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelColorInfo.Visible = false;
            this.Controls.Add(labelColorInfo);


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
                pictureBox2.Image = (Image)img.Clone();
                newOriginal = new Bitmap(img);
                editedImage = new Bitmap(img);
                currentSystem = "RGB";
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                viewSystemColorToolStripMenuItem.Text = "View System Color (RGB)";
                SetupChannels("Red", "Green", "Blue");

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
                pictureBox2.Image = (Image)img.Clone();
                newOriginal = new Bitmap(img);
                editedImage = new Bitmap(img);
                currentSystem = "RGB";
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                viewSystemColorToolStripMenuItem.Text = "View System Color (RGB)";
                SetupChannels("Red", "Green", "Blue");

            }
        }


        // ============================
        // التحويل بين الأنظمة اللونية
        // ============================

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "CMYK";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "HSV";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "YUV";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "LAB";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "YCbCr";

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
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
            isUpdatingTrackBar = true;
            if (colorReductionMode)
            {
                int originalColors = reducer.CountColors(newOriginal);
                trackBar1.Minimum = 1;
                trackBar1.Maximum = originalColors;
                trackBar1.Value = originalColors;
            }
            else
            {
           
                trackBar1.Minimum = -255;   
                trackBar1.Maximum = 255;
                trackBar1.Value = 0;
                
            }
            int Safe(int val)
            {
                return Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, val));
            }
            switch (currentSystem)
            {
                case "RGB":
                    if (selectedChannel == "Red") trackBar1.Value =Safe(r);
                    if (selectedChannel == "Green") trackBar1.Value = g;
                    if (selectedChannel == "Blue") trackBar1.Value = b;
                    break;

                case "CMYK":
                    if (selectedChannel == "Cyan") trackBar1.Value = Safe(c);
                    if (selectedChannel == "Magenta") trackBar1.Value = m;
                    if (selectedChannel == "Yellow") trackBar1.Value = yk;
                    if (selectedChannel == "Black") trackBar1.Value = k;
                    break;

                case "HSV":
                    if (selectedChannel == "Hue") trackBar1.Value = Safe(h);
                    if (selectedChannel == "Saturation") trackBar1.Value = s;
                    if (selectedChannel == "Value") trackBar1.Value = v;
                    break;

                case "YUV":
                    if (selectedChannel == "Y") trackBar1.Value = Safe(y);
                    if (selectedChannel == "U") trackBar1.Value = u;
                    if (selectedChannel == "V") trackBar1.Value = v2;
                    break;

                case "LAB":
                    if (selectedChannel == "L") trackBar1.Value = Safe(L);
                    if (selectedChannel == "A") trackBar1.Value = A;
                    if (selectedChannel == "B") trackBar1.Value = B;
                    break;

                case "YCbCr":
                    if (selectedChannel == "Y") trackBar1.Value = Safe(y3);
                    if (selectedChannel == "Cb") trackBar1.Value = cb;
                    if (selectedChannel == "Cr") trackBar1.Value = cr;
                    break;
            }

            isUpdatingTrackBar = false;

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
            if (isUpdatingTrackBar) return;

            if (newOriginal == null) return;

            int v = trackBar1.Value;

            // ============================
            //   وضع تقليل الألوان فقط
            // ============================
            if (colorReductionMode)
            {
                int step = 10;
                int maxColors = v - (v % step);

                editedImage = reducer.ReduceColors(newOriginal, maxColors);
                pictureBox1.Image = editedImage;

                int currentColors = reducer.CountColors((Bitmap)editedImage);

                labelColorInfo.Visible = true;
                labelColorInfo.Height = 20;
                labelColorInfo.TextAlign = ContentAlignment.MiddleCenter;
                labelColorInfo.Text = $"Colors: {currentColors}";
                labelColorInfo.BringToFront();

                return; // 🔥 يمنع أي نظام لوني من العمل
            }

            // ============================
            //   باقي الأنظمة اللونية
            // ============================
            switch (currentSystem)
            {
                case "RGB":
                    switch (selectedChannel)
                    {
                        case "Red": r = v; break;
                        case "Green": g = v; break;
                        case "Blue": b = v; break;
                    }
                    editedImage = adjust.AdjustRGB(newOriginal, r, g, b);
                    rgbEdited = (Bitmap)editedImage.Clone();
                    break;

                case "CMYK":
                    switch (selectedChannel)
                    {
                        case "Cyan": c = v; break;
                        case "Magenta": m = v; break;
                        case "Yellow": yk = v; break;
                        case "Black": k = v; break;
                    }
                    editedImage = adjust.AdjustCMYK(newOriginal, c, m, yk, k);
                    cmykEdited = (Bitmap)editedImage.Clone();
                    break;

                case "HSV":
                    switch (selectedChannel)
                    {
                        case "Hue": h = v; break;
                        case "Saturation": s = v; break;
                        case "Value": this.v = v; break;
                    }
                    editedImage = adjust.AdjustHSV(newOriginal, h, s, this.v);
                    hsvEdited = (Bitmap)editedImage.Clone();
                    break;

                case "YUV":
                    switch (selectedChannel)
                    {
                        case "Y": y = v; break;
                        case "U": u = v; break;
                        case "V": v2 = v; break;
                    }
                    editedImage = adjust.AdjustYUV(newOriginal, y, u, v2);
                    yuvEdited = (Bitmap)editedImage.Clone();
                    break;

                case "LAB":
                    switch (selectedChannel)
                    {
                        case "L": L = v; break;
                        case "A": A = v; break;
                        case "B": B = v; break;
                    }
                    editedImage = adjust.AdjustLAB(newOriginal, L, A, B);
                    labEdited = (Bitmap)editedImage.Clone();
                    break;

                case "YCbCr":
                    switch (selectedChannel)
                    {
                        case "Y": y3 = v; break;
                        case "Cb": cb = v; break;
                        case "Cr": cr = v; break;
                    }
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

            // 🔥 إعادة ضبط قيم الأنظمة اللونية
            r = g = b = 0;
            h = s = v = 0;
            y = u = v2 = 0;
            L = A = B = 0;
            y3 = cb = cr = 0;
            c = m = yk = k = 0;

            // 🔥 إذا كنا في وضع تقليل الألوان
            if (colorReductionMode)
            {
                int originalColors = reducer.CountColors(newOriginal);

                trackBar1.Minimum = 0;
                trackBar1.Maximum = originalColors;
                trackBar1.Value = originalColors;   // 🔥 المؤشر يرجع لأقصى اليمين

                labelColorInfo.Text = $"Colors: {originalColors}";
                labelColorInfo.Visible = true;
                labelColorInfo.BringToFront();
                return;
            }
            trackBar1.Minimum = -255;
            trackBar1.Maximum = 255;
            

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
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";
            SetupChannels("Red", "Green", "Blue");

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            viewSystemColorToolStripMenuItem.Text = "View System Color";


            if (colorReductionMode)
                return;

            editPanelVisible = !editPanelVisible;
            trackBar1.Visible = editPanelVisible;
            comboChannels.Visible = editPanelVisible;

            if (editPanelVisible)
            {
                int mid = (trackBar1.Minimum + trackBar1.Maximum) / 2;
                trackBar1.Value = mid;  
            }
        }

        private void viewSystemColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

            if (pictureBox2.Image == null) return;

            Bitmap bmp = (Bitmap)pictureBox2.Image;

            int x = e.X;
            int y = e.Y;

            if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height)
                return;

            Color c = bmp.GetPixel(x, y);

            var hsv = converter.RgbToHsv(c.R, c.G, c.B);
            var lab = converter.RgbToLab(c.R, c.G, c.B);
            var yuv = converter.RgbToYuv(c.R, c.G, c.B);
            var ycbcr = converter.RgbToYCbCr(c.R, c.G, c.B);
            var cmyk = converter.RgbToCmyk(c.R, c.G, c.B);
            labelColorInfo.Text =
    $"X:{x}  Y:{y}\n" +
    $"RGB: {c.R},{c.G},{c.B}      HSV: {hsv.H:F1},{hsv.S:F2},{hsv.V:F2}\n" +
    $"LAB: {lab.L:F1},{lab.a:F1},{lab.b:F1}   YUV: {yuv.Y:F1},{yuv.U:F1},{yuv.V:F1}\n" +
    $"YCbCr: {ycbcr.Y:F1},{ycbcr.Cb:F1},{ycbcr.Cr:F1}   CMYK: {cmyk.C:F2},{cmyk.M:F2},{cmyk.Y:F2},{cmyk.K:F2}";

        }




        private void viewPixelColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";
            SetupChannels("Red", "Green", "Blue");

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;

            pictureBox3.Visible = false;
            pictureBox2.Visible = !pictureBox2.Visible;
            labelColorInfo.Visible = pictureBox2.Visible;
        }

        private void twodViewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";
            SetupChannels("Red", "Green", "Blue");

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            is3D = false;

            pictureBox2.Visible = false;
            labelColorInfo.Visible = pictureBox2.Visible;
            viewSystemColorToolStripMenuItem.Text = "View Picture";
            // إخفاء الصورة الأصلية
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Image = null;

            // إظهار مكان العرض الرئيسي
            pictureBox3.Visible = true;
            pictureBox3.BringToFront();
            offsetX2D = 0;
            offsetY2D = 0;
            zoom2D = 1.0f;
            Bitmap bmp = currentSystem switch
            {
                "RGB" => shapes.DrawRGBCube(),
                "CMYK" => shapes.DrawCMYKCube(),
                "HSV" => shapes.DrawHSVShape(),
                "YUV" => shapes.DrawYUVShape(),
                "LAB" => shapes.DrawLABShape(),
                "YCbCr" => shapes.DrawYCbCrShape(),
                _ => null
            };

            if (bmp != null)
                pictureBox3.Tag = bmp;
            pictureBox3.Invalidate();
        }

        private void threedViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";
            SetupChannels("Red", "Green", "Blue");

            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            is3D = true;
            pictureBox2.Visible = false;
            labelColorInfo.Visible = pictureBox2.Visible;
            viewSystemColorToolStripMenuItem.Text = "View Picture"; // ← هون التغيير
            // إخفاء الصورة الأصلية
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;

            // إظهار 3D
            pictureBox3.Visible = true;
            pictureBox3.BringToFront();
            pictureBox3.Focus();

            DrawSystem3D();
        }


        private void pictureBoxSystem(object sender, EventArgs e)
        {


        }
        private void DrawSystem3D()
        {
            Bitmap bmp = currentSystem switch
            {
                "RGB" => shapes.DrawRGBCube3D(rotationX, rotationY, zoom),
                "CMYK" => shapes.DrawCMYK3D(rotationX, rotationY, zoom),
                "HSV" => shapes.DrawHSV3D(rotationX, rotationY, zoom),
                "LAB" => shapes.DrawLAB3D(rotationX, rotationY, zoom),
                "YUV" => shapes.DrawYUV3D(rotationX, rotationY, zoom),
                "YCbCr" => shapes.DrawYCbCr3D(rotationX, rotationY, zoom),
                _ => null
            };

            if (bmp != null)
                pictureBox3.Image = bmp;
            pictureBox3.Invalidate();

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            // if (!is3D) return;

            dragging = true;
            lastPoint = e.Location;
            pictureBox3.Focus();
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dragging) return;

            if (is3D)
            {
                rotationX += (e.Y - lastPoint.Y) * 0.5f;
                rotationY += (e.X - lastPoint.X) * 0.5f;
                DrawSystem3D();
            }
            else
            {
                offsetX2D += e.X - lastPoint.X;
                offsetY2D += e.Y - lastPoint.Y;
                pictureBox3.Invalidate();
            }
            lastPoint = e.Location;

        }
        private void pictureBox3_MouseWheel(object sender, MouseEventArgs e)
        {
            if (is3D)
            {
                zoom += e.Delta > 0 ? 0.1f : -0.1f;
                zoom = Math.Clamp(zoom, 0.2f, 5f);
                DrawSystem3D();
            }
            else
            {
                zoom2D += e.Delta > 0 ? 0.1f : -0.1f;
                zoom2D = Math.Clamp(zoom2D, 0.2f, 5f);
                pictureBox3.Invalidate();
            }

        }
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (is3D) return; // إذا 3D لا نرسم 2D

            if (pictureBox3.Tag == null) return;
            Bitmap bmp = (Bitmap)pictureBox3.Tag;
            // تحريك + تكبير
            e.Graphics.TranslateTransform(offsetX2D, offsetY2D);
            e.Graphics.ScaleTransform(zoom2D, zoom2D);

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void convertToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorCounterChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loader.OriginalImage == null)
            {
                var img = loader.LoadFromDialog(openFileDialog1);
                if (img != null)
                {
                    pictureBox1.Image = img;
                    pictureBox2.Image = (Image)img.Clone();
                    newOriginal = new Bitmap(img);
                    editedImage = new Bitmap(img);
                }
            }
            currentSystem = "RGB";
            SetupChannels("Red", "Green", "Blue");

            int originalColors = reducer.CountColors(newOriginal);

            trackBar1.Minimum = 1;
            trackBar1.Maximum = originalColors;
            trackBar1.Value = originalColors;

            colorReductionMode = !colorReductionMode;
            colorCounterChangeToolStripMenuItem.Checked = colorReductionMode;

            // 🔥 إخفاء زر convert to عند الدخول للوضع
            convertToToolStripMenuItem.Visible = !colorReductionMode;

            // إظهار/إخفاء الـ Panel
            editPanelVisible = colorReductionMode;
            trackBar1.Visible = editPanelVisible;

            // إخفاء القنوات أثناء وضع تقليل الألوان
            comboChannels.Visible = !colorReductionMode;

            // عند الخروج من الوضع نرجع الصورة كما كانت
            if (!colorReductionMode)
            {
                pictureBox1.Image = editedImage;
            }
        }


    }
}
