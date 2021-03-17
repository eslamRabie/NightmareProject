using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class GameGrid
    {
        public struct AaBb
        {
            public Vector3 TopLeft;
            public Vector3 TopRightDeltaZ;
            public Vector3 BottomRightDeltaXZ;
            public Vector3 BottomLeftDeltaX;

            public AaBb(Vector3 topLeft, Vector3 topRightDeltaZ, Vector3 bottomRightDeltaXZ, Vector3 bottomLeftDeltaX)
            {
                TopLeft = topLeft;
                TopRightDeltaZ = topRightDeltaZ;
                BottomRightDeltaXZ = bottomRightDeltaXZ;
                BottomLeftDeltaX = bottomLeftDeltaX;
            }                     
        }
        
        private LevelDifficultySO _levelDifficulty;
        private int _gridSize = 6;
        private Vector3 _origin;
        private Transform _parent;
        private int _id;

        
        private GameObject _level;

        private FloorPrefabsSO _floorPrefabs;
        
        private GameObject _playerElementPrefab;

        private AaBb _aabb;
        
        
        public GameGrid(Transform parent, LevelDifficultySO levelDifficulty, FloorPrefabsSO floorPrefabs, Vector3 origin, int gridSize, int id, string playerElement)
        {
            _parent = parent;
            _levelDifficulty = levelDifficulty;


            _floorPrefabs = floorPrefabs;
            _playerElementPrefab =
                floorPrefabs.floorPrefabs.Find(item => item.tag.ToLower() == playerElement.ToLower());
            
            _origin = origin;
            _gridSize = gridSize;
            _id = id;

            _aabb = new AaBb(origin, origin + (Vector3.forward * _gridSize),
                origin + ((Vector3.forward + Vector3.right) * _gridSize), origin + (Vector3.right * _gridSize));
            
            CreateLevel();
            
        }
        
        
        private void CreateLevel()
        {
            _level = new GameObject();
            _level.name = $"{_id}";
            _level.transform.parent = _parent;

            for (var i = 0; i < _gridSize; i++)
            for (var j = 0; j < _gridSize; j++)
                CreateCell(new Vector3(i,0,j), _level.transform, _playerElementPrefab.transform.localScale.x);

            // delete from here to create ofmesh links
            //NavMeshBuilder.BuildNavMesh();
        }


        private void CreateCell(Vector3 pos, Transform parent, float scale)
        {
            GameObject x;
            if (Random.Range(1, 101) <= _levelDifficulty.playerElementPercentage)
            {
                x = GameObject.Instantiate(_playerElementPrefab, pos, quaternion.identity, parent.transform);
            }
            else
            {
                x = GameObject.Instantiate(_floorPrefabs.floorPrefabs[Random.Range(0, _floorPrefabs.floorPrefabs.Count)],
                    pos, quaternion.identity, parent.transform);
            }
            x.transform.position = new Vector3(pos.x * scale, 0, pos.z * scale) + _origin;
            x.name = $"({pos.x}, {pos.z})";
            x.isStatic = true;
        }

        public AaBb GetAABB()
        {
            return _aabb;
        }


        public void GridDestroy()
        {
            GameObject.Destroy(_level);
        }
        
    }
}