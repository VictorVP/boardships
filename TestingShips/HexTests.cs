using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekShips;

namespace TestingShips
{
    [TestClass]
    public class HexTests
    {
        [TestMethod]
        public void VeerLeft()
        {
            HexDirection dir = HexDirection.DownLeft;
            var dir2 = dir.VeerLeft();
            Assert.AreEqual(HexDirection.Down, dir2);
        }

        [TestMethod]
        public void VeerRigth()
        {
            HexDirection dir = HexDirection.DownLeft;
            var dir2 = dir.VeerRight();
            Assert.AreEqual(HexDirection.UpLeft, dir2);
        }

        [TestMethod]
        public void VeerLeftBorderCondition()
        {
            HexDirection dir = HexDirection.UpRight;
            var dir2 = dir.VeerLeft();
            Assert.AreEqual(HexDirection.Up, dir2);
        }

        [TestMethod]
        public void VeerRightBorderCondition()
        {
            HexDirection dir = HexDirection.Up;
            var dir2 = dir.VeerRight();
            Assert.AreEqual(HexDirection.UpRight, dir2);
        }
    }
}
