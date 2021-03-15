using System;
using System.Collections.Generic;
using Levels.Scripts;
using Levels.Scripts.MysteryBox;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Scripts
{
    public class LevelManager
    {
        
        
        private List<GameGrid> _leveGridList;
        private PlayersPrefabsSO _playersPrefabs;
        private FloorPrefabsSO _floorPrefabs;
        private MysteryBoxPrefabsSO _mysteryBoxPrefabs;
        private LevelDifficultySO _levelDifficulty;
        private int _maxNumberOfLevels;
        private int _basicGridSize;
        private bool _isLevelCreated;
        private int _id;
        private int _numOfPlayers;
        private GameObject _currentLevelParent;


        public LevelManager(PlayersPrefabsSO playersPrefabs, FloorPrefabsSO floorPrefabs, MysteryBoxPrefabsSO mysteryBoxPrefabs,
            LevelDifficultySO levelDifficulty, int maxNumberOfLevels, int basicGridSize, int numOfPlayers)
        {
            _leveGridList = new List<GameGrid>();
            
            _playersPrefabs = playersPrefabs;
            _floorPrefabs = floorPrefabs;
            _mysteryBoxPrefabs = mysteryBoxPrefabs;
            _levelDifficulty = levelDifficulty;
            _maxNumberOfLevels = maxNumberOfLevels;
            _basicGridSize = basicGridSize;
            _numOfPlayers = numOfPlayers;
            
            _isLevelCreated = false;
            _id = 1;
            _currentLevelParent = new GameObject();

        }
        


        public GameObject CreateLevel(int playerLevel, string playerElement)
        {
            _isLevelCreated = true;

            ClearGridList();
            
            _currentLevelParent = new GameObject();
            Vector3 gridOrigin = Vector3.zero;
            int levelGridSize = _basicGridSize + playerLevel;
            CalculateDifficulty(playerLevel);
            for (int i = 0; i < _numOfPlayers; i++)
            {
                _leveGridList.Add(new GameGrid(_currentLevelParent.transform, _levelDifficulty, _floorPrefabs, gridOrigin, levelGridSize, _id,
                    playerElement));
                gridOrigin = CalculateGridOrigin(gridOrigin, levelGridSize);
                _id++;

            }
            
            DistributeMysteryBoxes();
            
            return _currentLevelParent;
        }


        bool ClearGridList()
        {
            if (_leveGridList.Count > 0)
            {
                foreach (var grid in _leveGridList)
                {
                    grid.GridDestroy();
                }
                _leveGridList.Clear();
                return true;
            }

            return false;
        }
        
        Vector3 CalculateGridOrigin(Vector3 gridOrigin, int levelGridSize)
        {
            return  new Vector3(gridOrigin.x + Random.Range(levelGridSize + 1, levelGridSize * 2),
                gridOrigin.y + Random.Range(levelGridSize + 1, levelGridSize * 2),
                gridOrigin.z + Random.Range(levelGridSize + 1, levelGridSize * 2));
        }
        

        void CalculateDifficulty(int playerLevel)
        {
            float maxMapDistance;
            //_levelDifficulty.playerElementPercentage = Mathf.Clamp(60 - (playerLevel / _maxNumberOfLevels), 0, 100);
            _levelDifficulty.numberOfHiddenEnemies = _numOfPlayers * Random.Range(1, 4);
            //_levelDifficulty.averageDistanceToMysteryBox = null;
            //_levelDifficulty.pathCostExtraMarginPercentage = 

        }


        void DistributeMysteryBoxes()
        {
            foreach (var boxType in _mysteryBoxPrefabs.mysteryBoxPrefabs)
            {
                var poses = DistributePlayers();
                foreach (var pos in poses)
                {
                    var posInY = pos + Vector3.up * _floorPrefabs.floorPrefabs[0].transform.localScale.y;
                    GameObject.Instantiate(boxType, posInY, Quaternion.identity);
                }
            }
        }
        
        
        /// <summary>
        /// gits the number of players and return a list of Vector3 positions one for each player 
        /// </summary>
        /// <param></param>
        /// <returns neme="listOfPositions"></returns>
        public List<Vector3> DistributePlayers()
        {
            List<Vector3> playerPositions = new List<Vector3>();
            foreach (var grid in _leveGridList)
            {
                GameGrid.AaBb aabb = grid.GetAABB();
                playerPositions.Add(new Vector3(Random.Range(aabb.TopLeft.x, aabb.BottomLeftDeltaX.x), aabb.TopLeft.y,
                    Random.Range(aabb.TopLeft.z, aabb.TopRightDeltaZ.z)));
            }

            return playerPositions;
        }
        
        
    }
}