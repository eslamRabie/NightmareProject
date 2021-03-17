using System;
using System.Collections.Generic;
using Level;
using Player;
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
        [SerializeField] private int maxNumberOfLevels;
        [SerializeField] private int basicGridSize;
        [SerializeField] private int numOfPlayers;
        [SerializeField] private UiManager _uiManager;

        [SerializeField] private GameObject player;
        
        private LevelManager _levelManager;
        private Player.Player _player;
        private GameObject oldParent;
        
        [SerializeField] private int playerLevel;

        private List<Player.Player> _playersList;
        
        private void Awake()
        {
            
            _levelManager = new LevelManager(playersPrefabs, floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            oldParent = _levelManager.CreateLevel(playerLevel, "fire");
            //_uiManager.
            _player = new Player.Player(playersPrefabs.playerPrefabs[0],floorPrefabs.floorPrefabs[0].transform.localScale.x,
                0, 200, 10, 10);
        }

        private void Update()
        {
            _player.UpdatePlayer();
        }


        public void CreateLevel()
        {
            Destroy(oldParent);
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            oldParent =  _levelManager.CreateLevel(playerLevel, "water");
        }

        
        
        
    }
}