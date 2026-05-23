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
        // ============================
        // تحويل نقطة واحدة (Pixel)
        // ============================

        public (double H, double S, double V) RgbToHsv(int r, int g, int b)
        {
            double rf = r / 255.0;
            double gf = g / 255.0;
            double bf = b / 255.0;

            double max = Math.Max(rf, Math.Max(gf, bf));
            double min = Math.Min(rf, Math.Min(gf, bf));
            double delta = max - min;

            double h = 0;
            if (delta != 0)
            {
                if (max == rf)
                    h = 60 * (((gf - bf) / delta) % 6);
                else if (max == gf)
                    h = 60 * (((bf - rf) / delta) + 2);
                else
                    h = 60 * (((rf - gf) / delta) + 4);
            }
            if (h < 0) h += 360;

            double s = max == 0 ? 0 : delta / max;
            double v = max;

            return (h, s, v);
        }

        public (double C, double M, double Y, double K) RgbToCmyk(int r, int g, int b)
        {
            double rf = r / 255.0;
            double gf = g / 255.0;
            double bf = b / 255.0;

            double k = 1 - Math.Max(rf, Math.Max(gf, bf));
            if (k >= 1.0) return (0, 0, 0, 1);

            double c = (1 - rf - k) / (1 - k);
            double m = (1 - gf - k) / (1 - k);
            double y = (1 - bf - k) / (1 - k);

            return (c, m, y, k);
        }

        public (double Y, double U, double V) RgbToYuv(int r, int g, int b)
        {
            double rf = r;
            double gf = g;
            double bf = b;

            double Y = 0.299 * rf + 0.587 * gf + 0.114 * bf;
            double U = -0.14713 * rf - 0.28886 * gf + 0.436 * bf;
            double V = 0.615 * rf - 0.51499 * gf - 0.10001 * bf;

            return (Y, U, V);
        }

        public (double Y, double Cb, double Cr) RgbToYCbCr(int r, int g, int b)
        {
            double rf = r;
            double gf = g;
            double bf = b;

            double Y = 16 + (65.738 * rf + 129.057 * gf + 25.064 * bf) / 256.0;
            double Cb = 128 + (-37.945 * rf - 74.494 * gf + 112.439 * bf) / 256.0;
            double Cr = 128 + (112.439 * rf - 94.154 * gf - 18.285 * bf) / 256.0;

            return (Y, Cb, Cr);
        }

        public (double L, double a, double b) RgbToLab(int r, int g, int b)
        {
            double rf = PivotRgb(r / 255.0);
            double gf = PivotRgb(g / 255.0);
            double bf = PivotRgb(b / 255.0);

            double X = rf * 0.4124 + gf * 0.3576 + bf * 0.1805;
            double Y = rf * 0.2126 + gf * 0.7152 + bf * 0.0722;
            double Z = rf * 0.0193 + gf * 0.1192 + bf * 0.9505;

            double Xn = 0.95047;
            double Yn = 1.00000;
            double Zn = 1.08883;

            double fx = PivotLab(X / Xn);
            double fy = PivotLab(Y / Yn);
            double fz = PivotLab(Z / Zn);

            double L = 116 * fy - 16;
            double a = 500 * (fx - fy);
            double bb = 200 * (fy - fz);

            return (L, a, bb);
        }

        private double PivotRgb(double n)
        {
            return (n > 0.04045) ? Math.Pow((n + 0.055) / 1.055, 2.4) : n / 12.92;
        }

        private double PivotLab(double t)
        {
            return t > 0.008856 ? Math.Pow(t, 1.0 / 3.0) : (7.787 * t) + (16.0 / 116.0);
        }

    }

}
