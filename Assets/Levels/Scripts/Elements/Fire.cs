using System;

namespace Levels.Scripts.Elements
{
    public class Fire: Element
    {
        
        private InteractiveObjectsDataSO attacker;
        
        public override string ToString()
        {
            return "Fire";
        }

        protected override void InteractWithFire()
        {
            DecreaseMana(attacker.ATK);
        }

        protected override void InteractWithWater()
        {
            DecreaseMana(attacker.ATK * 2f);
            
        }

        protected override void InteractWithIce()
        {
            DecreaseMana(attacker.ATK * 1.5f);
        }

        protected override void InteractWithWind()
        {
            DecreaseMana(attacker.Level * attacker.ATK);
        }

        protected override void InteractWithElectric()
        {
            DecreaseMana(attacker.Level * attacker.ATK);
        }

        protected override void InteractWithEarth()
        {
            DecreaseMana(attacker.ATK);
        }
    }
}