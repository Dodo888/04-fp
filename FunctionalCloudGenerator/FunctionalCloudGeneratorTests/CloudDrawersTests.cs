using System.Collections.Generic;
using System.Drawing;
using FunctionalCloudGenerator.CloudDrawers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalCloudGeneratorTests
{
    [TestClass]
    public class CloudDrawersTests
    {
        [TestMethod]
        public void Should_SelectAvailablePoint_NotAtTheStart()
        {
            var occupiedArea = new RectangleF(0, 0, 10, 10);
            var textSize = new SizeF(10, 10);
            var resultPoint = RandomCloudDrawer.DefineArea(new HashSet<RectangleF> { occupiedArea },
                textSize,
                new Point(30, 30));
            Assert.IsTrue(!HasIntersection(occupiedArea, resultPoint, textSize));
        }

        [TestMethod]
        public void Should_SelectAvailablePoint_NotAtTheMiddle()
        {
            var occupiedArea = new RectangleF(10, 10, 20, 20);
            var textSize = new SizeF(10, 10);
            var resultPoint = RandomCloudDrawer.DefineArea(new HashSet<RectangleF> { occupiedArea },
                textSize,
                new Point(30, 30));
            Assert.IsTrue(!HasIntersection(occupiedArea, resultPoint, textSize));
        }

        [TestMethod]
        public void Should_SelectAvailablePoint_NotAtTheEnd()
        {
            var occupiedArea = new RectangleF(20, 20, 30, 30);
            var textSize = new SizeF(10, 10);
            var resultPoint = RandomCloudDrawer.DefineArea(new HashSet<RectangleF> { occupiedArea },
                textSize,
                new Point(30, 30));
            Assert.IsTrue(!HasIntersection(occupiedArea, resultPoint, textSize));
        }

        public bool HasIntersection(RectangleF occupiedArea, Point offset, SizeF textSize)
        {
            var anotherArea = new RectangleF(offset, textSize);
            return occupiedArea.IntersectsWith(anotherArea);
        }
    }
}
