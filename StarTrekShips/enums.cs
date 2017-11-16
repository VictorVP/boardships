using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekShips
{
 public enum Movements
    {
        Stay,
        ChangeHeadingPort,
        ChangeHeadingStarboard,
        MoveForwardHalf,
        MoveForwardFull,
        MoveForwardChangeHeadingPort,
        MoveForwardChangeHeadingStarboard,
        SideslipPort,
        SideslipStarboard,
    }

    public static class HexDirectionExtensions
    {
        public static HexDirection VeerLeft(this HexDirection dir)
        {
            return GetNextHexDirection((int)dir + 1);
        }
        public static HexDirection VeerRight(this HexDirection dir)
        {
            return GetNextHexDirection((int)dir - 1);
        }

        private static HexDirection GetNextHexDirection(int v)
        {
            while (v < 0)
                v += 6;

            while (v > 5)
                v -= 6;

            return (HexDirection)v;
        }
    }
}
