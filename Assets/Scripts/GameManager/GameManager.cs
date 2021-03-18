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
        [SerializeField] private string playerElement;
        
        private GameObject _playerPrefab;
        private Player _player;
        
        private void Awake()
        {
            
            _levelManager = new LevelManager(floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            
            oldParent = _levelManager.CreateLevel(playerLevel, playerElement);
            //_uiManager.
            _playerPrefab = Instantiate(playersPrefabs.playerPrefabs[1].gameObject);

            CalculateMana();
            _player = _playerPrefab.GetComponent<Player>();
            _player.SetPosition(_levelManager.DistributePlayers()[0]);
            _player.CreatePlayer(playerElement, mana, floorPrefabs.floorPrefabs[0].transform.localScale.x, 0, 200, 10, 10);
            _player.PlayerLevel = playerLevel;
        }

        private void Update()
        {
            if (_player.GetKeyStatus())
            {
                //_uiManager.OnUiVictoryPannelCalled();
            }
            if(_player.GetDeadStatus())
            {
                //_uiManager.OnUiGameOverPannelCalled();
            }

        }


        public void CreateLevel()
        {
            Destroy(oldParent);
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            oldParent =  _levelManager.CreateLevel(playerLevel, playerElement);
        }

        void CalculateMana()
        {
            mana = basicGridSize * (basicGridSize / playerLevel);
        }
        
        
    }
}