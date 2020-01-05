using Microsoft.VisualStudio.TestTools.UnitTesting;
using AverageTextures;
using System.Drawing;

namespace AverageTexturesTests
{
    [TestClass]
    public class ImageProcessorTests
    {
        [TestMethod]
        public void testSetToAverageColor()
        {
            //arrange
            Bitmap bitmap = new Bitmap(1, 2);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            bitmap.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            Color color;
            Color expectedColor = Color.FromArgb(127, 127, 127);

            //act
            bitmap = ImageProcessor.setToAverageColor(bitmap);
            color = bitmap.GetPixel(0, 0);

            //assert
            Assert.AreEqual(expectedColor, color);
        }
    }
}
