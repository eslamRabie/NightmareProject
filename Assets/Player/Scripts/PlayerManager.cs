using System;
using Levels.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] PlayerStatusSO playerStatusSo;
        [SerializeField] private GridInfoSO gridInfoSo;

        private PlayerMovement _playerMovement;
        private NavMeshAgent _playerAgent;
        private NavMeshHit hit;
        bool tmp = true;
        private void Awake()
        {
            _playerMovement = new PlayerMovement(transform.position);
        }

        private void Start()
        {
            _playerAgent = gameObject.AddComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = 0.2f;
            _playerAgent.angularSpeed = 1;
        }

        private void FixedUpdate()
        {
            
            tmp = NavMesh.SamplePosition(_playerMovement.MovePlayer(transform.position, gridInfoSo.UnitGridSize,
                tmp), out hit, 1f, NavMesh.AllAreas);
            if (tmp)
            {
                _playerAgent.SetDestination(hit.position);
            }
        }

        public void GetMovementInput(InputAction.CallbackContext context)
        {
            if(context.performed)
                _playerMovement.UpdateMovementVector(context.ReadValue<Vector2>());
        }
        
        
    }
}