using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Scripts
{
    [CreateAssetMenu(fileName = "PlayerElementalPowerLevels", menuName = "PlayerElementalPowerLevels", order = 0)]
    public class PlayerElementalPowerLevels : ScriptableObject
    {
        [SerializeField] private float fire;
        [SerializeField] private float ice;
        [SerializeField] private float water;
        [SerializeField] private float wind;
        [SerializeField] private float earth;
        [SerializeField] private float electricity;
        [SerializeField] private ElementsObjects<float> _elementsVal;

        private PlayerElementalPowerLevels()
        {
            _elementsVal.SetElementValue("fire", fire);
            _elementsVal.SetElementValue("ice", ice);
            _elementsVal.SetElementValue("water", water);
            _elementsVal.SetElementValue("earth", earth);
            _elementsVal.SetElementValue("fire", fire);
            _elementsVal.SetElementValue("electricity", electricity);
        }
        
        public float GetPower(string element)
        {
            float val;
            if (!_elementsVal.GetElementValue(element, out val))
            {
                throw new ArgumentException("element not found or never set!");
            }
            return val;
        }

        public void SetPower(string element, float val)
        {
            if (!_elementsVal.GetElementValue(element, out val))
            {
                throw new ArgumentException("'element' not found or never set!");
            }
        }
        
    }
}