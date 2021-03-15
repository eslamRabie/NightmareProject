using System;
using System.Collections.Generic;
using Levels.Scripts;
using Player.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private PlayersPrefabsSO playersPrefabs;
        [SerializeField]private FloorPrefabsSO floorPrefabs;
        [SerializeField] private MysteryBoxPrefabsSO mysteryBoxPrefabs;
        [SerializeField] private LevelDifficultySO levelDifficulty;
        [SerializeField] private int maxNumberOfLevels;
        [SerializeField] private int basicGridSize;
        [SerializeField] private int numOfPlayers;
        
        
        private List<InteractiveObjectsDataSO> gameObjectsData;
        private LevelManager _levelManager;
        private PlayerManager _playerManager;
        private GameObject oldParent;
        
        
        [SerializeField] private int playerLevel;
        private void Awake()
        {
            _levelManager = new LevelManager(playersPrefabs, floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            _playerManager = gameObject.AddComponent<PlayerManager>();

            oldParent = _levelManager.CreateLevel(playerLevel, "fire");
            //_playerManager.CreatePlayer();


        }


        public void CreateLevel()
        {
            Destroy(oldParent);
            oldParent =  _levelManager.CreateLevel(playerLevel, "fire");
            Debug.Log(playerLevel);
        }
        
    }
}