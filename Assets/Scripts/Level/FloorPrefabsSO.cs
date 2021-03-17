using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "FloorPrefabsSO", menuName = "FloorPrefabsSO", order = 0)]
    public class FloorPrefabsSO : ScriptableObject
    {
        [SerializeField] public List<GameObject> floorPrefabs;

    }
}