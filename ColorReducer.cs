using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace project_1
{
    public class ColorReducer
    {
        public Bitmap ReduceColors(Bitmap original, int maxColors)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);

            int levels = (int)Math.Ceiling(Math.Pow(maxColors, 1.0 / 3.0));
            if (levels < 1) levels = 1;
            if (levels > 256) levels = 256;

            int step = 256 / levels;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original.GetPixel(x, y);

                    int r = (c.R / step) * step;
                    int g = (c.G / step) * step;
                    int b = (c.B / step) * step;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return bmp;
        }
        public int CountColors(Bitmap bmp)
        {
            HashSet<Color> set = new HashSet<Color>();

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    set.Add(bmp.GetPixel(x, y));

            return set.Count;
        }

    }

}
