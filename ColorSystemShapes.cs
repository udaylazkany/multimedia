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
        public Bitmap DrawRGBCube3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;

            // مصفوفة الدوران
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            // نرسم نقاط المكعب
            for (int r = 0; r <= 255; r += 20)
            {
                for (int g2 = 0; g2 <= 255; g2 += 20)
                {
                    for (int b = 0; b <= 255; b += 20)
                    {
                        // النقطة الأصلية في فضاء RGB
                        Vector3D p = new Vector3D(
                            r - 128,
                            g2 - 128,
                            b - 128
                        );

                        // دوران
                        p = m.Transform(p);

                        // تكبير
                        p = p * zoom;

                        // إسقاط 2D
                        int x = (int)(center + p.X);
                        int y = (int)(center - p.Y);

                        // رسم النقطة
                        if (x >= 0 && x < size && y >= 0 && y < size)
                        {
                            bmp.SetPixel(x, y, Color.FromArgb(r, g2, b));
                        }
                    }
                }
            }

            return bmp;
        }
        public Bitmap DrawCMYK3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            for (int C = 0; C <= 255; C += 20)
                for (int M = 0; M <= 255; M += 20)
                    for (int Y = 0; Y <= 255; Y += 20)
                    {
                        int K = 0;

                        int R = (int)((1 - C / 255f) * (1 - K / 255f) * 255);
                        int G = (int)((1 - M / 255f) * (1 - K / 255f) * 255);
                        int B = (int)((1 - Y / 255f) * (1 - K / 255f) * 255);

                        Vector3D p = new Vector3D(C - 128, M - 128, Y - 128);
                        p = m.Transform(p);
                        p = p * zoom;

                        int x = (int)(center + p.X);
                        int y = (int)(center - p.Y);

                        if (x >= 0 && x < size && y >= 0 && y < size)
                            bmp.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }

            return bmp;
        }
        public Bitmap DrawHSV3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            for (int H = 0; H < 360; H += 10)
                for (int S = 0; S <= 100; S += 10)
                    for (int V = 0; V <= 100; V += 10)
                    {
                        float rad = H * (float)Math.PI / 180f;

                        float x = (float)(S * Math.Cos(rad));
                        float z = (float)(S * Math.Sin(rad));
                        float y = V;

                        Vector3D p = new Vector3D(x, y, z);
                        p = m.Transform(p);
                        p = p * zoom;

                        int px = (int)(center + p.X);
                        int py = (int)(center - p.Y);

                        Color c = ColorFromHSV(H, S / 100f, V / 100f);

                        if (px >= 0 && px < size && py >= 0 && py < size)
                            bmp.SetPixel(px, py, c);
                    }

            return bmp;
        }
        public Bitmap DrawLAB3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            for (int L = 0; L <= 100; L += 5)
                for (int a = -128; a <= 127; a += 10)
                    for (int b = -128; b <= 127; b += 10)
                    {
                        Vector3D p = new Vector3D(a, L, b);
                        p = m.Transform(p);
                        p = p * zoom;

                        int x = (int)(center + p.X);
                        int y = (int)(center - p.Y);

                        Color c = LabToRgb(L, a, b);

                        if (x >= 0 && x < size && y >= 0 && y < size)
                            bmp.SetPixel(x, y, c);
                    }

            return bmp;
        }
        public Bitmap DrawYUV3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            for (int Y = 0; Y <= 255; Y += 20)
                for (int U = -128; U <= 127; U += 20)
                    for (int V = -128; V <= 127; V += 20)
                    {
                        Vector3D p = new Vector3D(U, Y, V);
                        p = m.Transform(p);
                        p = p * zoom;

                        int x = (int)(center + p.X);
                        int y = (int)(center - p.Y);

                        Color c = YuvToRgb(Y, U, V);

                        if (x >= 0 && x < size && y >= 0 && y < size)
                            bmp.SetPixel(x, y, c);
                    }

            return bmp;
        }
        public Bitmap DrawYCbCr3D(float rotX, float rotY, float zoom)
        {
            int size = 600;
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            int center = size / 2;
            Matrix3D m = Matrix3D.Rotation(rotX, rotY);

            for (int Y = 0; Y <= 255; Y += 20)
                for (int Cb = -128; Cb <= 127; Cb += 20)
                    for (int Cr = -128; Cr <= 127; Cr += 20)
                    {
                        Vector3D p = new Vector3D(Cb, Y, Cr);
                        p = m.Transform(p);
                        p = p * zoom;

                        int x = (int)(center + p.X);
                        int y = (int)(center - p.Y);

                        Color c = YCbCrToRgb(Y, Cb, Cr);

                        if (x >= 0 && x < size && y >= 0 && y < size)
                            bmp.SetPixel(x, y, c);
                    }

            return bmp;
        }
        public Color YuvToRgb(int Y, int U, int V)
        {
            // تحويل YUV إلى RGB وفق المعادلة القياسية
            double y = Y;
            double u = U - 128;
            double v = V - 128;

            int r = (int)(y + 1.402 * v);
            int g = (int)(y - 0.344136 * u - 0.714136 * v);
            int b = (int)(y + 1.772 * u);

            // قص القيم ضمن 0–255
            r = Math.Min(255, Math.Max(0, r));
            g = Math.Min(255, Math.Max(0, g));
            b = Math.Min(255, Math.Max(0, b));

            return Color.FromArgb(r, g, b);
        }
        public Color YCbCrToRgb(int Y, int Cb, int Cr)
        {
            // تحويل YCbCr إلى RGB وفق معيار BT.601
            double y = Y;
            double cb = Cb - 128;
            double cr = Cr - 128;

            int r = (int)(y + 1.402 * cr);
            int g = (int)(y - 0.344136 * cb - 0.714136 * cr);
            int b = (int)(y + 1.772 * cb);

            // قص القيم ضمن 0–255
            r = Math.Min(255, Math.Max(0, r));
            g = Math.Min(255, Math.Max(0, g));
            b = Math.Min(255, Math.Max(0, b));

            return Color.FromArgb(r, g, b);
        }
        public Color LabToRgb(double L, double a, double b)
        {
            // 1) تحويل LAB → XYZ
            double y = (L + 16) / 116.0;
            double x = a / 500.0 + y;
            double z = y - b / 200.0;

            double x3 = x * x * x;
            double y3 = y * y * y;
            double z3 = z * z * z;

            double refX = 95.047;
            double refY = 100.000;
            double refZ = 108.883;

            x = refX * (x3 > 0.008856 ? x3 : (x - 16.0 / 116.0) / 7.787);
            y = refY * (y3 > 0.008856 ? y3 : (y - 16.0 / 116.0) / 7.787);
            z = refZ * (z3 > 0.008856 ? z3 : (z - 16.0 / 116.0) / 7.787);

            // 2) تحويل XYZ → RGB
            x /= 100.0;
            y /= 100.0;
            z /= 100.0;

            double r = x * 3.2406 + y * -1.5372 + z * -0.4986;
            double g = x * -0.9689 + y * 1.8758 + z * 0.0415;
            double bl = x * 0.0557 + y * -0.2040 + z * 1.0570;

            // 3) تصحيح غاما
            r = (r > 0.0031308) ? (1.055 * Math.Pow(r, 1 / 2.4) - 0.055) : (12.92 * r);
            g = (g > 0.0031308) ? (1.055 * Math.Pow(g, 1 / 2.4) - 0.055) : (12.92 * g);
            bl = (bl > 0.0031308) ? (1.055 * Math.Pow(bl, 1 / 2.4) - 0.055) : (12.92 * bl);

            // 4) قص القيم ضمن 0–255
            int R = Math.Min(255, Math.Max(0, (int)(r * 255)));
            int G = Math.Min(255, Math.Max(0, (int)(g * 255)));
            int B = Math.Min(255, Math.Max(0, (int)(bl * 255)));

            return Color.FromArgb(R, G, B);
        }

    }
}
