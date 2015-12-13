using System.Drawing;
using System.Drawing.Imaging;

namespace FunctionalCloudGenerator.ApplicationTypes
{
    public static class ConsoleApplication
    {
        public static void CreateImage(Bitmap bitmap, string imagePath, ImageFormat format)
        {
                bitmap.Save(imagePath, format);
        }
    }
}
