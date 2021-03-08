using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Player.Scripts
{
    public class ElementsObjects <TElementValueType>
    {
        private Dictionary<string, Tuple<TElementValueType, bool>> _elementsMap;
        private const int numberOfElements = 6;
        private TElementValueType val;
        private Tuple<TElementValueType, bool> tuple;
        
        public ElementsObjects()
        {
            _elementsMap = new Dictionary<string, Tuple<TElementValueType, bool>>(numberOfElements);
            val = default(TElementValueType);
            tuple = new Tuple<TElementValueType, bool>(val, false);
            CreateMap();
        }
        
        private void CreateMap()
        {
            _elementsMap.Add("fire", tuple);
            _elementsMap.Add("water",  tuple);
            _elementsMap.Add("wind", tuple);
            _elementsMap.Add("ice",  tuple);
            _elementsMap.Add("earth",  tuple);
            _elementsMap.Add("electricity",  tuple);
        }

        /// <summary>
        /// Return true if the value is initialized false otherwise
        /// the value of the element can be retrieved through the value param if it was initialized.
        /// </summary>
        /// <param name="element">String</param>
        /// <param name="value">T</param>
        /// <returns name="SuccessState">bool</returns>
        public bool GetElementValue(string element, out TElementValueType value)
        {
            if (!_elementsMap.ContainsKey(element))
            {
                value = default(TElementValueType);
                return false;
            }
            Tuple<TElementValueType, bool> tmp = _elementsMap[element.ToLower()];
            value = tmp.Item1;
            return tmp.Item2;
        }

        
        public bool SetElementValue(string element, TElementValueType value)
        {
            if (!_elementsMap.ContainsKey(element))
            {
                value = default(TElementValueType);
                return false;
            }
            _elementsMap[element] = new Tuple<TElementValueType, bool>(value, true);
            return true;

        }

    }
}