using Levels.Scripts.Elements;
using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "InteractiveObjectsDataSO", menuName = "InteractiveObjectsDataSO", order = 0)]
    public class InteractiveObjectsDataSO : ScriptableObject
    {
        public string element;
        public int Level;
        public float DEF;
        public float DMG;
        public float ATK;
        public float Speed;
        public float Mana;
    }
}