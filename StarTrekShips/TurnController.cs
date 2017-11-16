using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekShips
{
   public class TurnController
    {
        public static int GetMovementPointsPerPhase(int totalMovement, int phase)
        {
            int remainder = totalMovement % 3;
            int quotient = totalMovement / 3;

            if ((remainder == 1 && phase == 2) || (remainder == 2 && phase != 2))
                    return quotient + 1;

            return quotient;
        }
    }

    public class ShipPowerAllocation
    {
        public Ship ship;
        public int MovementPower;
        public int ShieldsPower;
        public int WeaponsPower;

        public int MovementPoints { get { return MovementPower * ship.EnergyMovementRatio.Item2/ ship.EnergyMovementRatio.Item1; } }

        public int SetMovementPoints(int movePoints)
        {
            return movePoints * ship.EnergyMovementRatio.Item1 / ship.EnergyMovementRatio.Item2;

        }

        public int MaxMovementPoints
        {
            get
            {
                return ship.TotalPowerUnits - (ShieldsPower + WeaponsPower) * ship.EnergyMovementRatio.Item2 / ship.EnergyMovementRatio.Item1;
            }
        }

        public bool IsValidEnergyConfiguration()
        {
            return MovementPower + ShieldsPower + WeaponsPower <= ship.TotalPowerUnits;
        }
    }
}
