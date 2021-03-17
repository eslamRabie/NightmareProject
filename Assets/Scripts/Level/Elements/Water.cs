namespace Levels.Scripts.Elements
{
    public class Water: Element
    {
        
        private InteractiveObjectsDataSO attacker;
        

        public override string ToString()
        {
            return "Water";
        }

        protected override void InteractWithFire()
        {
            DecreaseMana(attacker.ATK * 1.5f);
        }

        protected override void InteractWithWater()
        {
            DecreaseMana(attacker.ATK);
            
        }

        protected override void InteractWithIce()
        {
            DecreaseMana(attacker.ATK);
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