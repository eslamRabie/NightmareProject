using System.Collections.Generic;
using System.Threading.Tasks;
using Level;
using Players;
using UnityEngine;
using UnityEngine.AI;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private PlayersPrefabsSO playersPrefabs;
        [SerializeField]private FloorPrefabsSO floorPrefabs;
        [SerializeField] private MysteryBoxPrefabsSO mysteryBoxPrefabs;
        [SerializeField] private LevelDifficultySO levelDifficulty;
        [SerializeField] private PlayerUiElemnt _playerUiElemnt;
        
        
        
        [SerializeField] private int maxNumberOfLevels;
        [SerializeField] private int basicGridSize;
        [SerializeField] private int numOfPlayers;
        [SerializeField] private UiManager _uiManager;
        [SerializeField] private UImangerLevel1 _level1UI;
        
        
        
        
        private LevelManager _levelManager;
        private GameObject _oldParent;
        
        private string _playerElement;
        private int _initialPlayerLevel = 1;
        
        
        private GameObject _playerPrefab;
        private Player _player;

        private NavMeshSurface _navMeshSurface;


        private void Awake()
        {
            _navMeshSurface = gameObject.GetComponent<NavMeshSurface>();
            _navMeshSurface.ignoreNavMeshObstacle = true;   
            _playerElement = _level1UI.abilitesIndex.ToString();
            
            _levelManager = new LevelManager(floorPrefabs, mysteryBoxPrefabs, levelDifficulty,
                maxNumberOfLevels, basicGridSize, numOfPlayers);
            
            _oldParent = _levelManager.CreateLevel(_initialPlayerLevel, _playerElement);
            
            _navMeshSurface.buildHeightMesh = false;
            _navMeshSurface.BuildNavMesh();
            
            _levelManager.DistributeMysteryBoxes();
            
            _playerPrefab = Instantiate(playersPrefabs.playerPrefabs[_level1UI.playerIndex].gameObject);

            _player = _playerPrefab.GetComponent<Player>();
            
            var playerPos = _levelManager.DistributePlayers()[0];
            var cellSize = floorPrefabs.floorPrefabs[0].transform.localScale.y;
            
            _player.CreatePlayer(playerPos, _playerElement, cellSize, 0, 900, 20, 10);
            
            _player.PlayerLevel = _initialPlayerLevel;
            
            _playerUiElemnt.PlayerAbilities[0].MaxAbilityValue = _player.CalculateMana(basicGridSize, maxNumberOfLevels);

           // Debug.Log($"{AbilityToString()}  {CharacterToString()}");
        }

        private void Update()
        {
            if (_player.GetKeyStatus())
            { 
                _player.PusePlayer();
                FindObjectOfType<AudioManager>().playAudio("Win");
                _uiManager.OnUiVictoryPannelCalled();
            }
            else if(_player.GetDeadStatus())
            {
                _player.PusePlayer();
                FindObjectOfType<AudioManager>().playAudio("Lose");
                _uiManager.OnUiGameOverPannelCalled();
            }

            _playerUiElemnt.PlayerAbilities[0].AbilityValue = _player.GetMana();

        }


        public void CreateLevel()
        {
            Destroy(_oldParent);
            _oldParent =  _levelManager.CreateLevel(_player.PlayerLevel, _playerElement);
            _navMeshSurface.buildHeightMesh = false;
            _navMeshSurface.BuildNavMesh();
            _levelManager.DistributeMysteryBoxes();
            PlayerNewLevel();
        }



        public void CreatLevelEvent()
        {            
            CreateLevel();
        }
       
        void PlayerNewLevel()
        {
            _player.PlayerLevel += 1;
            var playerPos = _levelManager.DistributePlayers()[0];
            var cellSize = floorPrefabs.floorPrefabs[0].transform.localScale.y;
            
            _player.CreatePlayer(playerPos, _playerElement, cellSize, 0, 200, 10, 10);
            
            _playerUiElemnt.PlayerAbilities[0].MaxAbilityValue = _player.CalculateMana(basicGridSize, maxNumberOfLevels);
        }

        public void UnPusePlayerEvent()
        {
            _player.UnPusePlayer();
        }
        
        
        
    }
}