﻿using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace Players
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private NavMeshAgent _playerAgent;
        private Animator _animator;
        private bool _hasKey;
        private string _element;
        private float _mana;
        private bool _isDead = false;
        public int PlayerLevel { get; set; }

        private void Awake()
        {
            gameObject.SetActive(false);
            _animator = GetComponentInChildren<Animator>();
        }

        
        
        public void CreatePlayer(string element, float mana, float cellSize, float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            _mana = mana;
            _playerMovement = new PlayerMovement(transform.position, cellSize);
            ConfigureAgent(stoppingDistance, angularSpeed, speed, acceleration);
            _hasKey = false;
            gameObject.SetActive(true);
            _element = element;
            _isDead = false;
            _animator.SetBool("IsDead", false);
        }
        
        

        public void GetMovementInputEventListener(InputAction.CallbackContext context)
        {
            if(context.performed)
                _playerMovement.UpdateMovementVector(context.ReadValue<Vector2>());
            
        }


        private void FixedUpdate()
        {
            if (!_isDead)
            {
                if (_playerAgent.isOnNavMesh)
                    _playerAgent.destination = _playerMovement.MovePlayer(transform);
                _animator.SetFloat("SpeedZ", _playerAgent.velocity.sqrMagnitude);
            }
        }
        
        
        void ConfigureAgent(float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            NavMeshBuilder.BuildNavMesh();
            if(NavMeshBuilder.isRunning) Debug.Log("running");
            _playerAgent = gameObject.AddComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = stoppingDistance;
            _playerAgent.angularSpeed = angularSpeed;
            _playerAgent.speed = speed;
            _playerAgent.acceleration = acceleration;
            //_playerAgent.baseOffset = 0.4f;
            _playerAgent.height = 1;
            _playerAgent.radius = 0.25f;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public bool GetKeyStatus()
        {
            return _hasKey;
        }

        public void AcquireKey()
        {
            _hasKey = true;
        }

        public float GetMana()
        {
            return _mana;
        }


        public void UpdateMana(float value)
        {
            _mana += value;
            if (_mana <= 0)
            {
                _animator.SetBool("IsDead", true);
                _isDead = true;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(_element))
            {
                UpdateMana(-5);
                _animator.SetTrigger("Pain");
                Debug.Log(_mana);
            }
            
        }

        public bool GetDeadStatus()
        {
            return _isDead;
        }
        
       
    }
}