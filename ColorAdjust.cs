using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace project_1
{
    internal class ColorAdjust
    {
        // ============================
        // 1) تعديل RGB
        // ============================
        public Bitmap AdjustRGB(Bitmap img, int addR, int addG, int addB)
        {
            Bitmap output = new Bitmap(img.Width, img.Height);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color p = img.GetPixel(x, y);

                    int r = Math.Clamp(p.R + addR, 0, 255);
                    int g = Math.Clamp(p.G + addG, 0, 255);
                    int b = Math.Clamp(p.B + addB, 0, 255);

                    output.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return output;
        }

        // ============================
        // 2) تعديل HSV
        // ============================
        public Bitmap AdjustHSV(Bitmap img, int addH, int addS, int addV)
        {
            string temp = Path.GetTempFileName();
            img.Save(temp);

            Mat bgr = CvInvoke.Imread(temp);
            Mat hsv = new Mat();

            CvInvoke.CvtColor(bgr, hsv, ColorConversion.Bgr2Hsv);

            unsafe
            {
                byte* data = (byte*)hsv.DataPointer;
                int total = hsv.Rows * hsv.Cols * 3;

                for (int i = 0; i < total; i += 3)
                {
                    int H = data[i] + addH;
                    int S = data[i + 1] + addS;
                    int V = data[i + 2] + addV;

                    data[i] = (byte)Math.Clamp(H, 0, 179);
                    data[i + 1] = (byte)Math.Clamp(S, 0, 255);
                    data[i + 2] = (byte)Math.Clamp(V, 0, 255);
                }
            }

            CvInvoke.CvtColor(hsv, bgr, ColorConversion.Hsv2Bgr);
            return bgr.ToBitmap();
        }

        // ============================
        // 3) تعديل YUV
        // ============================
        public Bitmap AdjustYUV(Bitmap img, int addY, int addU, int addV)
        {
            string temp = Path.GetTempFileName();
            img.Save(temp);

            Mat bgr = CvInvoke.Imread(temp);
            Mat yuv = new Mat();

            CvInvoke.CvtColor(bgr, yuv, ColorConversion.Bgr2Yuv);

            unsafe
            {
                byte* data = (byte*)yuv.DataPointer;
                int total = yuv.Rows * yuv.Cols * 3;

                for (int i = 0; i < total; i += 3)
                {
                    int Y = data[i] + addY;
                    int U = data[i + 1] + addU;
                    int V = data[i + 2] + addV;

                    data[i] = (byte)Math.Clamp(Y, 0, 255);
                    data[i + 1] = (byte)Math.Clamp(U, 0, 255);
                    data[i + 2] = (byte)Math.Clamp(V, 0, 255);
                }
            }

            CvInvoke.CvtColor(yuv, bgr, ColorConversion.Yuv2Bgr);
            return bgr.ToBitmap();
        }

        // ============================
        // 4) تعديل LAB
        // ============================
        public Bitmap AdjustLAB(Bitmap img, int addL, int addA, int addB)
        {
            string temp = Path.GetTempFileName();
            img.Save(temp);

            Mat bgr = CvInvoke.Imread(temp);
            Mat lab = new Mat();

            CvInvoke.CvtColor(bgr, lab, ColorConversion.Bgr2Lab);

            unsafe
            {
                byte* data = (byte*)lab.DataPointer;
                int total = lab.Rows * lab.Cols * 3;

                for (int i = 0; i < total; i += 3)
                {
                    int L = data[i] + addL;
                    int A = data[i + 1] + addA;
                    int B = data[i + 2] + addB;

                    data[i] = (byte)Math.Clamp(L, 0, 255);
                    data[i + 1] = (byte)Math.Clamp(A, 0, 255);
                    data[i + 2] = (byte)Math.Clamp(B, 0, 255);
                }
            }

            CvInvoke.CvtColor(lab, bgr, ColorConversion.Lab2Bgr);
            return bgr.ToBitmap();
        }

        // ============================
        // 5) تعديل YCbCr
        // ============================
        public Bitmap AdjustYCbCr(Bitmap img, int addY, int addCb, int addCr)
        {
            string temp = Path.GetTempFileName();
            img.Save(temp);

            Mat bgr = CvInvoke.Imread(temp);
            Mat ycc = new Mat();

            CvInvoke.CvtColor(bgr, ycc, ColorConversion.Bgr2YCrCb);

            unsafe
            {
                byte* data = (byte*)ycc.DataPointer;
                int total = ycc.Rows * ycc.Cols * 3;

                for (int i = 0; i < total; i += 3)
                {
                    int Y = data[i] + addY;
                    int Cb = data[i + 1] + addCb;
                    int Cr = data[i + 2] + addCr;

                    data[i] = (byte)Math.Clamp(Y, 0, 255);
                    data[i + 1] = (byte)Math.Clamp(Cb, 0, 255);
                    data[i + 2] = (byte)Math.Clamp(Cr, 0, 255);
                }
            }

            CvInvoke.CvtColor(ycc, bgr, ColorConversion.YCrCb2Bgr);
            return bgr.ToBitmap();
        }
        public Bitmap AdjustCMYK(Bitmap img, int addC, int addM, int addY, int addK)
        {
            Bitmap output = new Bitmap(img.Width, img.Height);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color p = img.GetPixel(x, y);

                    // RGB → CMY
                    double C = 1 - (p.R / 255.0);
                    double M = 1 - (p.G / 255.0);
                    double Y = 1 - (p.B / 255.0);

                    // K
                    double K = Math.Min(C, Math.Min(M, Y));

                    // حماية من القسمة على صفر
                    double oneMinusK = 1 - K;
                    if (oneMinusK <= 0.000001)
                    {
                        // بكسل أسود تقريباً
                        C = 0;
                        M = 0;
                        Y = 0;
                    }
                    else
                    {
                        C = (C - K) / oneMinusK;
                        M = (M - K) / oneMinusK;
                        Y = (Y - K) / oneMinusK;
                    }

                    // إضافة التعديلات (نفترض addC..addK من -255 إلى +255)
                    C = Math.Clamp(C + addC / 255.0, 0, 1);
                    M = Math.Clamp(M + addM / 255.0, 0, 1);
                    Y = Math.Clamp(Y + addY / 255.0, 0, 1);
                    K = Math.Clamp(K + addK / 255.0, 0, 1);

                    // CMYK → RGB
                    int R = (int)(255 * (1 - C) * (1 - K));
                    int G = (int)(255 * (1 - M) * (1 - K));
                    int B = (int)(255 * (1 - Y) * (1 - K));

                    R = Math.Clamp(R, 0, 255);
                    G = Math.Clamp(G, 0, 255);
                    B = Math.Clamp(B, 0, 255);

                    output.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return output;
        }

    }
}
