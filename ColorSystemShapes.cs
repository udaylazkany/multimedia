using System;
using System.Drawing;

namespace project_1
{
    public class ColorSystemShapes
    {
        // ============================
        // LAB
        // ============================
        public Bitmap DrawLABShape()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);

            for (int a = -128; a < 128; a++)
            {
                for (int b = -128; b < 128; b++)
                {
                    int x = a + 200;
                    int y = b + 200;

                    Color col = Color.FromArgb(
                        255 - Math.Abs(a),
                        255 - Math.Abs(b),
                        128
                    );

                    bmp.SetPixel(x, y, col);
                }
            }

            return bmp;
        }

        // ============================
        // YUV
        // ============================
        public Bitmap DrawYUVShape()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);

            for (int u = -128; u < 128; u++)
            {
                for (int v = -128; v < 128; v++)
                {
                    int x = u + 200;
                    int y = v + 200;

                    int Y = 128;

                    int R = (int)(Y + 1.402 * v);
                    int G = (int)(Y - 0.344 * u - 0.714 * v);
                    int B = (int)(Y + 1.772 * u);

                    R = Math.Max(0, Math.Min(255, R));
                    G = Math.Max(0, Math.Min(255, G));
                    B = Math.Max(0, Math.Min(255, B));

                    bmp.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return bmp;
        }

        // ============================
        // HSV
        // ============================
        public Bitmap DrawHSVShape()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);

            int cx = size / 2;
            int cy = size / 2;
            int radius = 150;

            for (int angle = 0; angle < 360; angle += 2)
            {
                for (int r = 0; r < radius; r += 2)
                {
                    double rad = angle * Math.PI / 180.0;

                    int x = cx + (int)(r * Math.Cos(rad));
                    int y = cy + (int)(r * Math.Sin(rad));

                    Color col = ColorFromHSV(angle, r / (double)radius, 1);

                    if (x >= 0 && x < size && y >= 0 && y < size)
                        bmp.SetPixel(x, y, col);
                }
            }

            return bmp;
        }

        private Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0: return Color.FromArgb(v, t, p);
                case 1: return Color.FromArgb(q, v, p);
                case 2: return Color.FromArgb(p, v, t);
                case 3: return Color.FromArgb(p, q, v);
                case 4: return Color.FromArgb(t, p, v);
                default: return Color.FromArgb(v, p, q);
            }
        }

        // ============================
        // CMYK
        // ============================
        public Bitmap DrawCMYKCube()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);

            for (int c = 0; c <= 255; c += 15)
            {
                for (int m = 0; m <= 255; m += 15)
                {
                    int x = c;
                    int y = m;

                    Color col = Color.FromArgb(255 - c, 255 - m, 0);

                    if (x < size && y < size)
                        bmp.SetPixel(x, y, col);
                }
            }

            return bmp;
        }

        // ============================
        // RGB Cube
        // ============================
        public Bitmap DrawRGBCube()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = 150;
            int cy = 150;
            int cube = 120;

            Point Project(int x, int y, int z)
            {
                int px = cx + x - z / 2;
                int py = cy + y - z / 2;
                return new Point(px, py);
            }

            for (int r = 0; r <= 255; r += 15)
            {
                for (int g2 = 0; g2 <= 255; g2 += 15)
                {
                    int x = (r * cube) / 255;
                    int y = (g2 * cube) / 255;

                    Point p = Project(x, y, 0);
                    bmp.SetPixel(p.X, p.Y, Color.FromArgb(r, g2, 0));

                    Point p2 = Project(cube, y, x);
                    bmp.SetPixel(p2.X, p2.Y, Color.FromArgb(255, g2, r));

                    Point p3 = Project(x, cube, y);
                    bmp.SetPixel(p3.X, p3.Y, Color.FromArgb(r, 255, g2));
                }
            }

            return bmp;
        }

        // ============================
        // YCbCr
        // ============================
        public Bitmap DrawYCbCrShape()
        {
            int size = 400;
            Bitmap bmp = new Bitmap(size, size);

            for (int cb = 0; cb < 255; cb++)
            {
                for (int cr = 0; cr < 255; cr++)
                {
                    int x = cb;
                    int y = cr;

                    int Y = 128;

                    int R = (int)(Y + 1.402 * (cr - 128));
                    int G = (int)(Y - 0.34414 * (cb - 128) - 0.71414 * (cr - 128));
                    int B = (int)(Y + 1.772 * (cb - 128));

                    R = Math.Max(0, Math.Min(255, R));
                    G = Math.Max(0, Math.Min(255, G));
                    B = Math.Max(0, Math.Min(255, B));

                    bmp.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return bmp;
        }
    }
}
