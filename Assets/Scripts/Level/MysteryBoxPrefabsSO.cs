using System.Collections.Generic;
using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "MysteryBoxPrefabsSO", menuName = "MysteryBoxPrefabsSO", order = 0)]
    public class MysteryBoxPrefabsSO : ScriptableObject
    {
        [SerializeField] public List<GameObject> mysteryBoxPrefabs;
    }
}