using System.Drawing;
using System.Windows.Forms;

namespace project_1
{
    public class ImageLoader
    {
        public Image OriginalImage { get; private set; }

        public Image LoadFromDialog(OpenFileDialog dialog)
        {
            dialog.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                OriginalImage = (Image)img.Clone();
                return img;
            }

            return null;
        }

        public Image LoadFromPath(string path)
        {
            Image img = Image.FromFile(path);
            OriginalImage = (Image)img.Clone();
            return img;
        }
    }
}
