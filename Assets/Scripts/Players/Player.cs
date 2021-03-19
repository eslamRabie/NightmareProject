using System;
using System.Threading.Tasks;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


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

        private Rigidbody _rg;
        
        public int PlayerLevel { get; set; }

        private bool _isPause;
        private bool _isCreated = false;

        private Vector2 _deltaMouse;

        private void Awake()
        {
            gameObject.SetActive(false);
            _animator = GetComponentInChildren<Animator>();
            _isPause = true;
            _rg = GetComponent<Rigidbody>();
        }

        
        
        public void CreatePlayer(Vector3 playerPosition, string element, float cellSize, float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            transform.position = playerPosition;
            if (!_isCreated)
            {
                _isCreated = true;
                _playerMovement = new PlayerMovement(transform.position, cellSize);
                ConfigureAgent(stoppingDistance, angularSpeed, speed, acceleration);
                gameObject.SetActive(true);
                _element = element;
            }

            _hasKey = false;
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
            if (!_isDead && !_isPause)
            {
                if (_playerAgent.isOnNavMesh)
                {
                    _playerAgent.destination = _playerMovement.MovePlayer(transform);;
                }
                _animator.SetFloat("SpeedZ", _playerAgent.velocity.sqrMagnitude);
            }
            else
            {
                _animator.SetFloat("SpeedZ", 0);
            }
        }
        
        
        async void ConfigureAgent(float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            _isPause = true;
            //if(NavMeshBuilder.isRunning) Debug.Log("running");
            _playerAgent = gameObject.GetComponent<NavMeshAgent>();
            _playerAgent.stoppingDistance = stoppingDistance;
            _playerAgent.angularSpeed = angularSpeed;
            _playerAgent.speed = speed;
            _playerAgent.acceleration = acceleration;
            _playerAgent.baseOffset = -0.07f;
            _playerAgent.height = 1;
            _playerAgent.radius = 0.25f;
            _isPause = false;
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
            //_playerCamera.transform.rotation = Quaternion.Slerp();
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
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(_element))
            {   
                UpdateMana(-1);
               // _animator.SetTrigger("Pain");
            }
            
        }

        public bool GetDeadStatus()
        {
            return _isDead;
        }


        public void PusePlayer()
        {
            _isPause = true;
        }
        public void UnPusePlayer()
        {
            _isPause = false;
        }
        
        public float CalculateMana(float basicGridSize, int maxNumOfLevels)
        {
            _mana = (int)Random.Range((PlayerLevel + basicGridSize), (PlayerLevel + basicGridSize) * 2);
            return _mana;
        }
       
        async void DecreaseMana()
        {
            await Task.Delay(100);
            _mana--;
        }

        
        
    }
}