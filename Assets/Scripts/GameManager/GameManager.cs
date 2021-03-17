using System;
using System.Collections.Generic;
using Levels.Scripts;
using Player.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private PlayersPrefabsSO playersPrefabs;
        [SerializeField]private FloorPrefabsSO floorPrefabs;
        [SerializeField] private MysteryBoxPrefabsSO mysteryBoxPrefabs;
        [SerializeField] private LevelDifficultySO levelDifficulty;
        [SerializeField] private GridInfoSO gridInfoSo;
        [SerializeField] private InteractiveObjectsDataSO playerStatus;
        [SerializeField] private int maxNumberOfLevels;
        [SerializeField] private int basicGridSize;
        [SerializeField] private int numOfPlayers;

        [SerializeField] private GameObject player;
        
        private List<InteractiveObjectsDataSO> gameObjectsData;
        private LevelManager _levelManager;
        private PlayerManager _playerManager;
        private GameObject oldParent;
        
        
        [SerializeField] private int playerLevel;
        private void Awake()
        {
            
            _levelManager = new LevelManager(playersPrefabs, floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            oldParent = _levelManager.CreateLevel(playerLevel, "fire");
            
            
            
            
            _playerManager = player.GetComponent<PlayerManager>();
            
            
            


        }


        public void CreateLevel()
        {
            Destroy(oldParent);
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            oldParent =  _levelManager.CreateLevel(playerLevel, "water");
            Debug.Log(playerLevel);
        }
        
    }
}