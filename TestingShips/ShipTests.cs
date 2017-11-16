using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekShips;

namespace TestingShips
{
    [TestClass]
    public class ShipTests
    {
        #region Ship Movements

        [TestMethod]
        public void StayMovementTest()
        {
            var ship = new Ship();
            var position = new Hex(0, 0, 0);
            var heading = HexDirection.Up;
            ship.Position = position;
            ship.Heading = heading;

            ship.Move(Movements.Stay);

            Assert.AreEqual(position, ship.Position);
            Assert.AreEqual(heading, ship.Heading);
        }

        [TestMethod]
        public void ChangeHeadingPortMovementTest()
        {
            var ship = new Ship();
            var position = new Hex(0, 0, 0);
            var heading = HexDirection.Up;
            ship.Position = position;
            ship.Heading = heading;

            ship.Move(Movements.ChangeHeadingPort);
            var newHeading = HexDirection.UpLeft;
            Assert.AreEqual(position, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);
        }

        [TestMethod]
        public void ChangeHeadingStarboardMovementTest()
        {
            var ship = new Ship();
            var position = new Hex(0, 0, 0);
            var heading = HexDirection.Up;
            ship.Position = position;
            ship.Heading = heading;

            ship.Move(Movements.ChangeHeadingStarboard);
            var newHeading = HexDirection.UpRight;
            Assert.AreEqual(position, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);
        }

        [TestMethod]
        public void MoveForwardHalf()
        {
            var ship = new Ship();
            var position = new Hex(2, -2, 0);
            var heading = HexDirection.DownRight;
            ship.Position = position;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardHalf);
            var newPos = new Hex(1, -1, 0);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);

            ship.Position = new Hex(2, -2, 0);
            heading = HexDirection.DownLeft;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardHalf);
            newPos = new Hex(2, -3, 1);
            Assert.AreEqual(heading, ship.Heading);
            Assert.AreEqual(newPos, ship.Position);
        }

        [TestMethod]
        public void MoveForwardFull()
        {
            var ship = new Ship();
            var position = new Hex(0, -3, 3);
            var heading = HexDirection.UpRight;
            ship.Position = position;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardFull);
            var newPos = new Hex(0, -1, 1);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);

            ship.Position = new Hex(-2, 3, -1);
            heading = HexDirection.UpLeft;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardFull);
            newPos = new Hex(0, 1, -1);
            Assert.AreEqual(heading, ship.Heading);
            Assert.AreEqual(newPos, ship.Position);
        }

        [TestMethod]
        public void MoveForwardChangeHeadingPort()
        {
            var ship = new Ship();
            var position = new Hex(0, -3, 3);
            var heading = HexDirection.UpRight;
            ship.Position = position;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardChangeHeadingPort);
            var newPos = new Hex(0, -2, 2);
            var newHeading = HexDirection.Up;
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);

            heading = HexDirection.DownLeft;
            ship.Position = new Hex(2, -2, 0);
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardChangeHeadingPort);
            newPos = new Hex(2, -3, 1);
            newHeading = HexDirection.Down;
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);
        }

        [TestMethod]
        public void MoveForwardChangeHeadingStarboard()
        {
            var ship = new Ship();
            var position = new Hex(0, -3, 3);
            var heading = HexDirection.UpRight;
            ship.Position = position;
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardChangeHeadingStarboard);
            var newPos = new Hex(0, -2, 2);
            var newHeading = HexDirection.DownRight;
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);

            heading = HexDirection.DownLeft;
            ship.Position = new Hex(2, -2, 0);
            ship.Heading = heading;
            ship.Move(Movements.MoveForwardChangeHeadingStarboard);
            newPos = new Hex(2, -3, 1);
            newHeading = HexDirection.UpLeft;
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(newHeading, ship.Heading);
        }

        [TestMethod]
        public void SideslipPort()
        {
            var ship = new Ship();
            ship.Position = new Hex(-2, 0, 2);
            var heading = HexDirection.UpLeft;
            ship.Heading = heading;
            ship.Move(Movements.SideslipPort);
            var newPos = new Hex(-1, -2, 3);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);

            ship.Position = new Hex(-1, 2, -1);
            heading = HexDirection.Down;
            ship.Heading = heading;
            ship.Move(Movements.SideslipPort);
            newPos = new Hex(-3, 3, 0);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);
        }

        [TestMethod]
        public void SideslipStarboard()
        {
            var ship = new Ship();
            ship.Position = new Hex(1, -2, 1);
            var heading = HexDirection.UpRight;
            ship.Heading = heading;
            ship.Move(Movements.SideslipStarboard);
            var newPos = new Hex(0, 0, 0);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);

            ship.Position = new Hex(-3, 2, 1);
            heading = HexDirection.Up;
            ship.Heading = heading;
            ship.Move(Movements.SideslipStarboard);
            newPos = new Hex(-2, 3, -1);
            Assert.AreEqual(newPos, ship.Position);
            Assert.AreEqual(heading, ship.Heading);
        }

        #endregion

        #region Movement points per phase
        [TestMethod]
        public void MovementsPerPhase()
        {
            Assert.AreEqual(0, TurnController.GetMovementPointsPerPhase(1, 1));
            Assert.AreEqual(1, TurnController.GetMovementPointsPerPhase(1, 2));
            Assert.AreEqual(5, TurnController.GetMovementPointsPerPhase(16, 3));
            Assert.AreEqual(6, TurnController.GetMovementPointsPerPhase(16, 2));
            Assert.AreEqual(5, TurnController.GetMovementPointsPerPhase(17, 2));
            Assert.AreEqual(6, TurnController.GetMovementPointsPerPhase(17, 1));
        }
        #endregion
    }
}
