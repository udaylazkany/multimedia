using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    internal class SavePicture
    {
        public void Save(Bitmap editedImage) {

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
