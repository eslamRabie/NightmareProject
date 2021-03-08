using System.Collections.Generic;
using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "LevelDataSO", menuName = "LevelDataSO", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] public List<GameObject> LevelObjects;
    }
}