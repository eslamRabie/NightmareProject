using System.Collections.Generic;
using Player.Scripts;
using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "FloorPrefabsSO", menuName = "FloorPrefabsSO", order = 0)]
    public class FloorPrefabsSO : ScriptableObject
    {
        [SerializeField] public List<GameObject> floorPrefabs;

    }
}