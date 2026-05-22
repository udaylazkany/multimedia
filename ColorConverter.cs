using System.Drawing;
using Emgu.CV;

namespace project_1
{
    public class ColorConverter
    {
        convert_class converter = new convert_class();

        public Image ToRGB(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.rgbcolor(p);
            return p.Image;
        }

        public Image ToCMYK(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.cmykcolor(p);
            return p.Image;
        }

        public Image ToHSV(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.hsvcolor(p);
            return p.Image;
        }

        public Image ToYUV(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.YUVcolor(p);
            return p.Image;
        }

        public Image ToLAB(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.LABcolor(p);
            return p.Image;
        }

        public Image ToYCbCr(Image img)
        {
            PictureBox p = new PictureBox();
            p.Image = (Image)img.Clone();
            converter.yCbCrcolor(p);
            return p.Image;
        }
    }
}
