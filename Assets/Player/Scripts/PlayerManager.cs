using System;
using Levels.Scripts;
using Levels.Scripts.Elements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] InteractiveObjectsDataSO playerStatusSo;
        [SerializeField] private GridInfoSO gridInfoSo;

        private Element _playerElement;
        private PlayerMovement _playerMovement;
        private NavMeshAgent _playerAgent;
        private NavMeshHit hit;
        bool tmp = true;
        
        
        private void Awake()
        {
            _playerMovement = new PlayerMovement(transform.position, gridInfoSo);
            _playerElement = GetComponent<Element>();
            _playerElement.SetData(playerStatusSo);
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
            if(context.performed)
                _playerMovement.UpdateMovementVector(context.ReadValue<Vector2>());
        }


        public void CreatePlayer()
        {
            
        }
        
        void ConfigureAgent()
        {
            _playerAgent = gameObject.AddComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = 0.0f;
            _playerAgent.angularSpeed = 9999;
            _playerAgent.speed = 20;
            _playerAgent.acceleration = 20;
        }
        
        
        
    }
}