using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekShips
{
    public class Ship
    {
        public Hex Position;
        public HexDirection Heading;
        public int TotalPowerUnits;
        public Tuple<int, int> EnergyMovementRatio;

        private List<ShipSystem> m_systems;
        public int HullPoints { get; private set; }

        public void Move(Movements m)
        {
            switch (m)
            {
                case Movements.Stay:
                    break;
                case Movements.ChangeHeadingPort:
                    {
                        Heading = Heading.VeerLeft();
                        break;
                    }
                case Movements.ChangeHeadingStarboard:
                    {
                        Heading = Heading.VeerRight();
                        break;
                    }
                case Movements.MoveForwardHalf:
                    {
                        var neighbor = Hex.GetNeighborAtDirection(Heading);
                        Position = Position.Add(neighbor);
                        break;
                    }
                case Movements.MoveForwardFull:
                    {
                        var neighbor = Hex.GetNeighborAtDirection(Heading);
                        Position = Position.Add(neighbor.Multiply(2));
                        break;
                    }
                case Movements.MoveForwardChangeHeadingPort:
                    {
                        Position = Position.Add(Hex.GetNeighborAtDirection(Heading));
                        Heading = Heading.VeerLeft();
                        break;
                    }
                case Movements.MoveForwardChangeHeadingStarboard:
                    {
                        Position = Position.Add(Hex.GetNeighborAtDirection(Heading));
                        Heading = Heading.VeerRight();
                        break;
                    }
                case Movements.SideslipPort:
                    {
                        var sideStepDirection = Hex.GetNeighborAtDirection(Heading.VeerLeft());
                        var sideStep = sideStepDirection.Add(Position);
                        Position = sideStep.Add(Hex.GetNeighborAtDirection(Heading));
                        break;
                    }
                case Movements.SideslipStarboard:
                    {
                        var sideStepDirection = Hex.GetNeighborAtDirection(Heading.VeerRight());
                        var sideStep = sideStepDirection.Add(Position);
                        Position = sideStep.Add(Hex.GetNeighborAtDirection(Heading));
                        break;
                    }
            }
        }

        public int GetMovementPoints(int energy)
        {
            return energy * EnergyMovementRatio.Item1 / EnergyMovementRatio.Item2;
        }
    }
}
