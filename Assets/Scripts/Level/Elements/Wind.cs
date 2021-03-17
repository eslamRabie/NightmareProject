namespace Levels.Scripts.Elements
{
    public class Wind : Element
    {
       

        private InteractiveObjectsDataSO attacker;
        
        

        public override string ToString()
        {
            return "Wind";
        }

        protected override void InteractWithFire()
        {
            DecreaseMana(attacker.ATK);
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
            DecreaseMana(attacker.ATK);
        }

        protected override void InteractWithElectric()
        {
            DecreaseMana(attacker.ATK);
        }

        protected override void InteractWithEarth()
        {
            DecreaseMana(attacker.ATK);
        }
    }
}