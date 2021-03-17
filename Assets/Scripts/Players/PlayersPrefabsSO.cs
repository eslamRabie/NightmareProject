using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    [CreateAssetMenu(fileName = "PlayersPrefabsSO", menuName = "PlayersPrefabsSO", order = 0)]
    public class PlayersPrefabsSO : ScriptableObject
    {
        [SerializeField] public List<GameObject> playerPrefabs;
    }
}