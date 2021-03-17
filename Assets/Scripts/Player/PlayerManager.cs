using System;
using Levels.Scripts;
using Levels.Scripts.Elements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace Player.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] public InteractiveObjectsDataSO playerStatusSo;
        [SerializeField] public GridInfoSO gridInfoSo;
        
        private PlayerMovement _playerMovement;
        
        private NavMeshAgent _playerAgent;
        
        private NavMeshHit hit;
        bool tmp = true;
        
        
        private void Awake()
        {
            
            _playerMovement = new PlayerMovement(transform.position, gridInfoSo);
            gameObject.SetActive(false);
        }

        private void Start()
        {
            ConfigureAgent();
            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if(_playerAgent.isOnNavMesh)
                _playerAgent.destination = _playerMovement.MovePlayer(transform);
        }

        public void GetMovementInput(InputAction.CallbackContext context)
        {
            Debug.Log("input");
            if(context.performed)
                _playerMovement.UpdateMovementVector(context.ReadValue<Vector2>());
        }


        public void CreatePlayer()
        {
            
        }
        
        void ConfigureAgent()
        {
            NavMeshBuilder.BuildNavMesh();
            if(NavMeshBuilder.isRunning) Debug.Log("running");
            _playerAgent = this.gameObject.AddComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = 0.0f;
            _playerAgent.angularSpeed = 9999;
            _playerAgent.speed = 20;
            _playerAgent.acceleration = 20;
            
        }
        
        
        
    }
}