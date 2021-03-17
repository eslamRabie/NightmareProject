﻿using System.Collections.Generic;
using UnityEngine;

namespace Player.Scripts
{
    [CreateAssetMenu(fileName = "PlayersPrefabsSO", menuName = "PlayersPrefabsSO", order = 0)]
    public class PlayersPrefabsSO : ScriptableObject
    {
        [SerializeField] public List<GameObject> playerPrefabs;
    }
}