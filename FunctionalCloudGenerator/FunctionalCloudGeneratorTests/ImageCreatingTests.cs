using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FunctionalCloudGenerator.ApplicationTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalCloudGeneratorTests
{
    [TestClass]
    public class ImageCreatingTests
    {
        [TestMethod]
        public void PngImage_shouldBeCreated()
        {
            if (File.Exists("tests/image.png"))
                File.Delete("tests/image.png");
            ConsoleApplication.CreateImage(new Bitmap(1, 1), "tests/image.png", ImageFormat.Png);
            Assert.IsTrue(File.Exists("tests/image.png"));
        }

        [TestMethod]
        public void JpegImage_shouldBeCreated()
        {
            if (File.Exists("tests/image.jpeg"))
                File.Delete("tests/image.jpeg");
            ConsoleApplication.CreateImage(new Bitmap(1, 1), "tests/image.jpeg", ImageFormat.Jpeg);
            Assert.IsTrue(File.Exists("tests/image.jpeg"));
        }

        [TestMethod]
        public void BmpImage_shouldBeCreated()
        {
            if (File.Exists("tests/image.bmp"))
                File.Delete("tests/image.bmp");
            ConsoleApplication.CreateImage(new Bitmap(1, 1), "tests/image.bmp", ImageFormat.Bmp);
            Assert.IsTrue(File.Exists("tests/image.bmp"));
        }
    }
}
