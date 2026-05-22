using System.Drawing;

namespace project_1
{
    public class ColorAdjuster
    {
        ColorAdjust adjuster = new ColorAdjust();

        public Bitmap AdjustRGB(Bitmap img, int r, int g, int b)
        {
            return adjuster.AdjustRGB(img, r, g, b);
        }

        public Bitmap AdjustCMYK(Bitmap img, int c, int m, int y, int k)
        {
            return adjuster.AdjustCMYK(img, c, m, y, k);
        }

        public Bitmap AdjustHSV(Bitmap img, int h, int s, int v)
        {
            return adjuster.AdjustHSV(img, h, s, v);
        }

        public Bitmap AdjustYUV(Bitmap img, int y, int u, int v2)
        {
            return adjuster.AdjustYUV(img, y, u, v2);
        }

        public Bitmap AdjustLAB(Bitmap img, int L, int A, int B)
        {
            return adjuster.AdjustLAB(img, L, A, B);
        }

        public Bitmap AdjustYCbCr(Bitmap img, int y, int cb, int cr)
        {
            return adjuster.AdjustYCbCr(img, y, cb, cr);
        }
    }
}
