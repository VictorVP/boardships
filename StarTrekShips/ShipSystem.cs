using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekShips
{
    enum ShipSystemType
    {
        Engine,
        Weapon,
        Shielp,
        LifeSupport,
    }

    public abstract class ShipSystem
    {
        public int CurrentDamage { get; set; }
        public int MaxDamage { get; }

        public bool Active { get; set; }

        public bool IsDestroyec {
            get { return (CurrentDamage <= MaxDamage);}
        }

        private Ship m_ship;
        public void TakeDamage(int damage)
        {
            CurrentDamage += damage;

            if (CurrentDamage >= MaxDamage)
            {

            }
        }
    }
}
