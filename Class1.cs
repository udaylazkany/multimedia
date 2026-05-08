using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1
{
    internal class convert_class
    {
        public void rgbcolor(PictureBox pictureBox
            )
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة لعرضها");
                return;
            }

            Bitmap rgbimage = new Bitmap(pictureBox.Image);
            Bitmap rgbcomponentImage = new Bitmap(rgbimage.Width, rgbimage.Height);
            
            for (int y = 0; y < rgbimage.Height; y++)
            {
                for (int x = 0; x < rgbimage.Width; x++)
                {
                    Color pixelcolor = rgbimage.GetPixel(x, y);

                    int redcomponent = pixelcolor.R;
                    int greencomponent = pixelcolor.G;
                    int bluecomponent = pixelcolor.B;

                    Color rgbcolor = Color.FromArgb(redcomponent, greencomponent, bluecomponent);
                    rgbcomponentImage.SetPixel(x, y, rgbcolor);
                }
            }

            // عرض الصورة الناتجة داخل PictureBox
            pictureBox.Image = rgbcomponentImage;   // أو greencomponentImage أو bluecomponentImage
        }
        public void cmykcolor(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة لعرضها");
                return;
            }

            Bitmap rgbimage = new Bitmap(pictureBox.Image);
            Bitmap cmykImage = new Bitmap(rgbimage.Width, rgbimage.Height);

            for (int y = 0; y < rgbimage.Height; y++)
            {
                for (int x = 0; x < rgbimage.Width; x++)
                {
                    Color pixel = rgbimage.GetPixel(x, y);

                    // تحويل RGB إلى قيم بين 0 و 1
                    double r = pixel.R / 255.0;
                    double g = pixel.G / 255.0;
                    double b = pixel.B / 255.0;

                    // حساب K
                    double K = 1 - Math.Max(r, Math.Max(g, b));

                    // تجنب القسمة على صفر
                    double C = (1 - r - K) / (1 - K + 0.00001);
                    double M = (1 - g - K) / (1 - K + 0.00001);
                    double Y = (1 - b - K) / (1 - K + 0.00001);

                    // تحويل القيم إلى 0–255
                    int C255 = (int)(C * 255);
                    int M255 = (int)(M * 255);
                    int Y255 = (int)(Y * 255);
                    int K255 = (int)(K * 255);

                    // عرض CMYK كصورة RGB (C,M,Y فقط)
                    Color displayColor = Color.FromArgb(C255, M255, Y255);

                    cmykImage.SetPixel(x, y, displayColor);
                }
            }

            pictureBox.Image = cmykImage;
        }
        public void hsvcolor(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة");
                return;
            }
            string tempPath = Path.GetTempFileName();
            pictureBox.Image.Save(tempPath);
            Mat rgbMat = CvInvoke.Imread(tempPath);
            Mat hsvMat = new Mat();
            CvInvoke.CvtColor(rgbMat, hsvMat, ColorConversion.Bgr2Hsv);
            Bitmap bmp = hsvMat.ToBitmap();
            pictureBox.Image = bmp;
        }
        public void YUVcolor(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة");
                return;
            }
            string tempPath = Path.GetTempFileName();
            pictureBox.Image.Save(tempPath);
            Mat rgbMat = CvInvoke.Imread(tempPath);
            Mat hsvMat = new Mat();
            CvInvoke.CvtColor(rgbMat, hsvMat, ColorConversion.Bgr2Yuv);
            Bitmap bmp = hsvMat.ToBitmap();
            pictureBox.Image = bmp;
        }

        public void LABcolor(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة");
                return;
            }
            string tempPath = Path.GetTempFileName();
            pictureBox.Image.Save(tempPath);
            Mat rgbMat = CvInvoke.Imread(tempPath);
            Mat hsvMat = new Mat();
            CvInvoke.CvtColor(rgbMat, hsvMat, ColorConversion.Bgr2Lab);
            Bitmap bmp = hsvMat.ToBitmap();
            pictureBox.Image = bmp;
        }
        public void yCbCrcolor(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("لا توجد صورة");
                return;
            }
            string tempPath = Path.GetTempFileName();
            pictureBox.Image.Save(tempPath);
            Mat rgbMat = CvInvoke.Imread(tempPath);
            Mat hsvMat = new Mat();
            CvInvoke.CvtColor(rgbMat, hsvMat, ColorConversion.Bgr2YCrCb);
            Bitmap bmp = hsvMat.ToBitmap();
            pictureBox.Image = bmp;
        }
    }
}
