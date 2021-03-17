using System.Collections.Generic;
using Level;
using Players;
using UnityEngine;
using UnityEngine.AI;
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
        
        
        
        
        private LevelManager _levelManager;
        private GameObject oldParent;
        
        [SerializeField] private int playerLevel;
        [SerializeField] private float mana;

        
        private GameObject _playerPrefab;
        private Player _player;
        
        private void Awake()
        {
            
            _levelManager = new LevelManager(floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            
            oldParent = _levelManager.CreateLevel(playerLevel, "fire");
            //_uiManager.
            _playerPrefab = Instantiate(playersPrefabs.playerPrefabs[0].gameObject);

            _player = _playerPrefab.GetComponent<Player>();
            _player.CreatePlayer(mana, floorPrefabs.floorPrefabs[0].transform.localScale.x, 0, 200, 10, 10);
            _player.PlayerLevel = playerLevel;
            _player.SetPosition(_levelManager.DistributePlayers()[0]);
        }

        private void Update()
        {
            if (_player.GetKeyStatus())
            {
                _uiManager.OnUiVictoryPannelCalled();
            }

        }


        public void CreateLevel()
        {
            Destroy(oldParent);
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            oldParent =  _levelManager.CreateLevel(playerLevel, "water");
        }

        void CalculateMana()
        {
            
        }
        
        
    }
}