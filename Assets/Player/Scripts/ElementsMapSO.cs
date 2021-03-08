using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Scripts
{
    [CreateAssetMenu(fileName = "ElementsMap", menuName = "ElementsMap", order = 0)]
    public class ElementsMapSO : ScriptableObject
    {
        private Dictionary<string, Type > _elementsMap;

        

        public Type GetElement(string elementName)
        {
            if (_elementsMap is null)
            {
                CreateMap();
            }

            return _elementsMap[elementName.ToLower()];

        }
        
        void CreateMap()
        {
            _elementsMap = new Dictionary<string, Type>(6);
            _elementsMap.Add("fire",  typeof(Fire));
            _elementsMap.Add("water",  typeof(Water));
            _elementsMap.Add("wind",  typeof(Wind));
            _elementsMap.Add("ice",  typeof(Ice));
            _elementsMap.Add("earth",  typeof(Earth));
            _elementsMap.Add("electricity",  typeof(Electricity));

        }
        
    }
}