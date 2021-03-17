using System;
using UnityEngine;

namespace Levels.Scripts.Elements
{
    public enum Debuffs
    {
        FREEZE, BURN, SWIRL, OVERLOAD, SUPERCONDUCT, ELECTROCHARGE, MELT, VAPORIZE  
    }
    
    
    public abstract class Element : MonoBehaviour
    {
        protected InteractiveObjectsDataSO _data;

        public void SetData(InteractiveObjectsDataSO data)
        {
            _data = data;
        }
        
        public void ElementalInteraction(string attackerElement, InteractiveObjectsDataSO ATker)
        {
            if(attackerElement != ToString())
                switch (attackerElement)
                {
                    case "Fire":
                        InteractWithFire();
                        break;
                    case "Water":
                        InteractWithWater();
                        break;
                    case "Ice":
                        InteractWithIce();
                        break;
                    case "Wind":
                        InteractWithWind();
                        break;
                    case "Electric":
                        InteractWithElectric();
                        break;
                    case "Earth":
                        InteractWithEarth();
                        break;
                }
        }
        protected void DecreaseMana(float percentage)
        {
            _data.Mana -= (percentage + _data.DEF);
        }
        public abstract override string ToString();
        
        protected abstract void InteractWithFire();
        protected abstract void InteractWithWater();
        protected abstract void InteractWithIce();
        protected abstract void InteractWithWind();
        protected abstract void InteractWithElectric();
        protected abstract void InteractWithEarth();


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("player");
                other.gameObject.GetComponent<Element>().ElementalInteraction(this.ToString(), _data);
            }
        }
    }
}