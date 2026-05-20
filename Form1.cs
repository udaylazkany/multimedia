using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace project_1
{
    public partial class Form1 : Form
    {
        bool editPanelVisible = false;

        private Image originalImage;

        convert_class convert_color_to = new convert_class();
        ColorAdjust adjuster = new ColorAdjust();

        Bitmap neworiginalImage;
        Bitmap editedImage;
        string currentColorSystem = "";
        string selectedChannel = "";
        int rValue = 0, gValue = 0, bValue = 0;
        int hValue = 0, sValue = 0, vValue = 0;
        int yValue = 0, uValue = 0, v2Value = 0;
        int LValue = 0, AValue = 0, BValue = 0;
        int y3Value = 0, cbValue = 0, crValue = 0;
        int cValue = 0, mValue = 0, ykValue = 0, kValue = 0;


        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            trackBar1.Scroll += trackBar1_Scroll;
            comboChannels.SelectedIndexChanged += comboChannels_SelectedIndexChanged;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                originalImage = (Image)pictureBox1.Image.Clone();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                pictureBox1.Image = Image.FromFile(files[0]);
                originalImage = (Image)pictureBox1.Image.Clone();
            }
        }

        // ================================
        //  التحويل بين الأنظمة اللونية
        // ================================

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.rgbcolor(pictureBox1);

            currentColorSystem = "RGB";
            neworiginalImage = new Bitmap(pictureBox1.Image);
            editedImage = new Bitmap(neworiginalImage);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("Red");
            comboChannels.Items.Add("Green");
            comboChannels.Items.Add("Blue");
            comboChannels.SelectedIndex = 0;
        }

        private void cMYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.cmykcolor(pictureBox1);

            currentColorSystem = "CMYK";
            neworiginalImage = new Bitmap(pictureBox1.Image);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("Cyan");
            comboChannels.Items.Add("Magenta");
            comboChannels.Items.Add("Yellow");
            comboChannels.Items.Add("Black");
            comboChannels.SelectedIndex = 0;
        }

        private void hSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.hsvcolor(pictureBox1);

            currentColorSystem = "HSV";
            neworiginalImage = new Bitmap(pictureBox1.Image);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("Hue");
            comboChannels.Items.Add("Saturation");
            comboChannels.Items.Add("Value");
            comboChannels.SelectedIndex = 0;
        }

        private void yUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.YUVcolor(pictureBox1);

            currentColorSystem = "YUV";
            neworiginalImage = new Bitmap(pictureBox1.Image);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("Y");
            comboChannels.Items.Add("U");
            comboChannels.Items.Add("V");
            comboChannels.SelectedIndex = 0;
        }

        private void lABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.LABcolor(pictureBox1);

            currentColorSystem = "LAB";
            neworiginalImage = new Bitmap(pictureBox1.Image);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("L");
            comboChannels.Items.Add("A");
            comboChannels.Items.Add("B");
            comboChannels.SelectedIndex = 0;
        }

        private void yCBCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)originalImage.Clone();
            convert_color_to.yCbCrcolor(pictureBox1);

            currentColorSystem = "YCbCr";
            neworiginalImage = new Bitmap(pictureBox1.Image);

            comboChannels.Items.Clear();
            comboChannels.Items.Add("Y");
            comboChannels.Items.Add("Cb");
            comboChannels.Items.Add("Cr");
            comboChannels.SelectedIndex = 0;
        }

        // ================================
        //  اختيار القناة
        // ================================

        private void comboChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedChannel = comboChannels.SelectedItem.ToString();

            switch (currentColorSystem)
            {
                case "RGB":
                    if (selectedChannel == "Red") trackBar1.Value = rValue;
                    if (selectedChannel == "Green") trackBar1.Value = gValue;
                    if (selectedChannel == "Blue") trackBar1.Value = bValue;
                    break;

                case "CMYK":
                    if (selectedChannel == "Cyan") trackBar1.Value = cValue;
                    if (selectedChannel == "Magenta") trackBar1.Value = mValue;
                    if (selectedChannel == "Yellow") trackBar1.Value = ykValue;
                    if (selectedChannel == "Black") trackBar1.Value = kValue;
                    break;

                case "HSV":
                    if (selectedChannel == "Hue") trackBar1.Value = hValue;
                    if (selectedChannel == "Saturation") trackBar1.Value = sValue;
                    if (selectedChannel == "Value") trackBar1.Value = vValue;
                    break;

                case "YUV":
                    if (selectedChannel == "Y") trackBar1.Value = yValue;
                    if (selectedChannel == "U") trackBar1.Value = uValue;
                    if (selectedChannel == "V") trackBar1.Value = v2Value;
                    break;

                case "LAB":
                    if (selectedChannel == "L") trackBar1.Value = LValue;
                    if (selectedChannel == "A") trackBar1.Value = AValue;
                    if (selectedChannel == "B") trackBar1.Value = BValue;
                    break;

                case "YCbCr":
                    if (selectedChannel == "Y") trackBar1.Value = y3Value;
                    if (selectedChannel == "Cb") trackBar1.Value = cbValue;
                    if (selectedChannel == "Cr") trackBar1.Value = crValue;
                    break;
            }
        }


        // ================================
        //  التعديل عبر TrackBar
        // ================================

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (neworiginalImage == null) return;
            if (selectedChannel == "") return;

            int v = trackBar1.Value;

            switch (currentColorSystem)
            {
                // ============================
                // RGB
                // ============================
                case "RGB":

                    if (selectedChannel == "Red") rValue = v;
                    if (selectedChannel == "Green") gValue = v;
                    if (selectedChannel == "Blue") bValue = v;

                    editedImage = adjuster.AdjustRGB(
                        neworiginalImage,
                        rValue,
                        gValue,
                        bValue
                    );

                    pictureBox1.Image = editedImage;
                    break;

                // ============================
                // CMYK
                // ============================
                case "CMYK":

                    if (selectedChannel == "Cyan") cValue = v;
                    if (selectedChannel == "Magenta") mValue = v;
                    if (selectedChannel == "Yellow") ykValue = v;
                    if (selectedChannel == "Black") kValue = v;

                    editedImage = adjuster.AdjustCMYK(
                        neworiginalImage,
                        cValue,
                        mValue,
                        ykValue,
                        kValue
                    );

                    pictureBox1.Image = editedImage;
                    break;




                // ============================
                // HSV
                // ============================


                case "HSV":

                    if (selectedChannel == "Hue") hValue = v;
                    if (selectedChannel == "Saturation") sValue = v;
                    if (selectedChannel == "Value") vValue = v;

                    editedImage = adjuster.AdjustHSV(
                        neworiginalImage,
                        hValue,
                        sValue,
                        vValue
                    );

                    pictureBox1.Image = editedImage;
                    break;

                // ============================
                // YUV
                // ============================
                case "YUV":

                    if (selectedChannel == "Y") yValue = v;
                    if (selectedChannel == "U") uValue = v;
                    if (selectedChannel == "V") v2Value = v;

                    editedImage = adjuster.AdjustYUV(
                        neworiginalImage,
                        yValue,
                        uValue,
                        v2Value
                    );

                    pictureBox1.Image = editedImage;
                    break;

                // ============================
                // LAB
                // ============================
                case "LAB":

                    if (selectedChannel == "L") LValue = v;
                    if (selectedChannel == "A") AValue = v;
                    if (selectedChannel == "B") BValue = v;

                    editedImage = adjuster.AdjustLAB(
                        neworiginalImage,
                        LValue,
                        AValue,
                        BValue
                    );

                    pictureBox1.Image = editedImage;
                    break;

                // ============================
                // YCbCr
                // ============================
                case "YCbCr":

                    if (selectedChannel == "Y") y3Value = v;
                    if (selectedChannel == "Cb") cbValue = v;
                    if (selectedChannel == "Cr") crValue = v;

                    editedImage = adjuster.AdjustYCbCr(
                        neworiginalImage,
                        y3Value,
                        cbValue,
                        crValue
                    );

                    pictureBox1.Image = editedImage;
                    break;
            }
        }

        private void Editpicture_Click(object sender, EventArgs e)
        {
            editPanelVisible = !editPanelVisible;
            trackBar1.Visible = editPanelVisible;
            comboChannels.Visible = editPanelVisible;

        }

        private void resetColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            // 1) رجوع الصورة الأصلية
            pictureBox1.Image = (Image)originalImage.Clone();

            // 2) تحديث الصور الأساسية
            neworiginalImage = new Bitmap(pictureBox1.Image);
            editedImage = new Bitmap(neworiginalImage);

            // 3) تصفير كل قيم القنوات
            rValue = gValue = bValue = 0;
            hValue = sValue = vValue = 0;
            yValue = uValue = v2Value = 0;
            LValue = AValue = BValue = 0;
            y3Value = cbValue = crValue = 0;
            cValue = mValue = ykValue = kValue = 0;   // CMYK

            // 4) تصفير TrackBar
            trackBar1.Value = 0;

            // 5) إعادة اختيار أول قناة في القائمة
            if (comboChannels.Items.Count > 0)
                comboChannels.SelectedIndex = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("لا توجد صورة معروضة حالياً.", "معلومات الصورة");
                return;
            }

            // الحصول على مسار الصورة
            string filePath = openFileDialog1.FileName;

            // معلومات الملف
            FileInfo info = new FileInfo(filePath);

            // معلومات الصورة
            Bitmap bmp = new Bitmap(originalImage);

            string details =
                $"📌 معلومات الصورة:\n\n" +
                $"• اسم الملف: {info.Name}\n" +
                $"• المسار الكامل: {info.FullName}\n" +
                $"• الحجم: {info.Length / 1024.0:F2} KB\n" +
                $"• النوع: {bmp.RawFormat}\n" +
                $"• العرض: {bmp.Width} بكسل\n" +
                $"• الارتفاع: {bmp.Height} بكسل\n" +
                $"• عدد البكسلات: {bmp.Width * bmp.Height}\n" +
                $"• عمق الألوان: {bmp.PixelFormat}\n" +
                $"• DPI أفقي: {bmp.HorizontalResolution}\n" +
                $"• DPI عمودي: {bmp.VerticalResolution}\n" +
                $"• تاريخ الإنشاء: {info.CreationTime}\n" +
                $"• آخر تعديل: {info.LastWriteTime}\n";

            MessageBox.Show(details, "About Image");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editedImage == null)
            {
                MessageBox.Show("لا توجد صورة معدّلة لحفظها.", "تنبيه");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "حفظ الصورة";
            save.Filter = "JPEG Image (*.jpg)|*.jpg|PNG Image (*.png)|*.png|Bitmap (*.bmp)|*.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    editedImage.Save(save.FileName);
                    MessageBox.Show("تم حفظ الصورة بنجاح!", "نجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحفظ:\n" + ex.Message, "خطأ");
                }
            }
        }

    }
}
