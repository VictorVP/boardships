using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekShips
{
    public enum HexDirection
    {
        Up,
        UpLeft,
        DownLeft,
        Down,
        DownRight,
        UpRight,
    }

    public class Hex
    {
        private static List<Hex> m_directions;
        public static List<Hex> Directions
        {
            get
            {
                if (m_directions == null)
                {
                    m_directions = new List<Hex>();
                    m_directions.Add(new Hex(1, 0, -1));
                    m_directions.Add(new Hex(1, -1, 0));
                    m_directions.Add(new Hex(0, -1, 1));
                    m_directions.Add(new Hex(-1, 0, 1));
                    m_directions.Add(new Hex(-1, 1, 0));
                    m_directions.Add(new Hex(0, 1, -1));
                }

                return m_directions;
            }
        }

        public static Hex GetNeighborAtDirection(HexDirection direction)
        {
            return Directions[(int)direction];
        }

        int[] pos = new  int[3];

        private int Q
        {
            get { return pos[0]; }
        }

        private int R
        {
            get { return pos[1]; }
        }

        private int S
        {
            get { return pos[2]; }
        }

        public Hex(int q, int r, int s)
        {
            if (s != -q - r)
                throw new Exception("Invalid hex coordinate");
            pos[0] = q;
            pos[1] = r;
            pos[2] = s;
        }

        public Hex(int q, int r)
        {
            pos[0] = q;
            pos[1] = r;
            pos[2] = -q - r;
        }

        public Hex Add(Hex other)
        {
            return new Hex(this.Q + other.Q, this.R + other.R);
        }

        public Hex Subtract(Hex other)
        {
            return new Hex(this.Q - other.Q, this.R - other.R);
        }

        public Hex Multiply(int f)
        {
            return new Hex(Q * f, R * f);
        }

        public int DistanceTo(Hex other)
        {
            return (Math.Abs(Q - other.Q) + Math.Abs(R - other.R) + Math.Abs(S - other.S)) / 2;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Hex;
            if (other == null)
                return false;
            return R == other.R && Q == other.Q;
        }

        public override int GetHashCode()
        {
            return 1000 * R + 100 * Q + S;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", Q, R, S);
        }
    }
}
