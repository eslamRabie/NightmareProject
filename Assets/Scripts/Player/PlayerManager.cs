using System;
using Levels.Scripts;
using Levels.Scripts.Elements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace Player.Scripts
{
    public class PlayerManager
    {
        private PlayerMovement _playerMovement;
        private NavMeshAgent _playerAgent;
        private GameObject _playerPrefab;

        private bool _hasKey;


        public PlayerManager(GameObject playerPrefab, int cellSize, float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            _playerPrefab = playerPrefab;
            _playerMovement = new PlayerMovement(_playerPrefab.transform.position, cellSize);
            ConfigureAgent(stoppingDistance, angularSpeed, speed, acceleration);
            _hasKey = false;
        }

        public void GetMovementInputEventListener(InputAction.CallbackContext context)
        {
            if(context.performed)
                _playerMovement.UpdateMovementVector(context.ReadValue<Vector2>());
        }


        public void UpdatePlayer()
        {
            if(_playerAgent.isOnNavMesh)
                _playerAgent.destination = _playerMovement.MovePlayer(_playerPrefab.transform);
        }
        
        
        void ConfigureAgent(float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            NavMeshBuilder.BuildNavMesh();
            if(NavMeshBuilder.isRunning) Debug.Log("running");
            _playerAgent = _playerPrefab.gameObject.AddComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = stoppingDistance;
            _playerAgent.angularSpeed = angularSpeed;
            _playerAgent.speed = speed;
            _playerAgent.acceleration = acceleration;
        }

        public void SetPosition(Vector3 position)
        {
            _playerPrefab.transform.position = position;
        }

        public bool GetKeyStatus()
        {
            return _hasKey;
        }

        public void AcquireKey()
        {
            _hasKey = true;
        }
        
    }
}