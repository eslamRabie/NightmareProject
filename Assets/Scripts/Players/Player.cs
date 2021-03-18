using System;
using Cinemachine;
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

        //private CinemachineFreeLook _playerCamera;
        public int PlayerLevel { get; set; }

        private bool _isPause;
        private bool _isCreated = false;

        private Vector2 _deltaMouse;

        private void Awake()
        {
            gameObject.SetActive(false);
            _animator = GetComponentInChildren<Animator>();
            
            /*_playerCamera = GetComponentInChildren<CinemachineFreeLook>();
            CinemachineCore.GetInputAxis = GetAxisCustom;*/
            
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
        
        
        
        public void ControllCamera(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                RotateCamera(context.ReadValue<Vector2>());
            }
        }

        public float GetAxisCustom(string axisName)
        {
            var LookDelta = _deltaMouse;
            LookDelta.Normalize();
            if (axisName == "Mouse X")
            {
                return LookDelta.x;
            }
            if (axisName == "Mouse Y")
            {
                Debug.Log(LookDelta);
                _deltaMouse = Vector2.zero;
                return LookDelta.y;
            }
            return 0;
        }
        
        
        void RotateCamera(Vector2 delta)
        {
            _deltaMouse = delta;
        }
        
        
        private void FixedUpdate()
        {
            if (!_isDead)
            {
                if (_playerAgent.isOnNavMesh)
                {
                    _playerAgent.destination = _playerMovement.MovePlayer(transform);;
                }
                _animator.SetFloat("SpeedZ", _playerAgent.velocity.sqrMagnitude);
            }
        }
        
        
        void ConfigureAgent(float stoppingDistance, float angularSpeed, float speed, float acceleration)
        {
            NavMeshBuilder.BuildNavMesh();
            //if(NavMeshBuilder.isRunning) Debug.Log("running");
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

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(_element))
            {
                UpdateMana(-1);
               // _animator.SetTrigger("Pain");
                Debug.Log(_mana);
            }
            
        }

        public bool GetDeadStatus()
        {
            return _isDead;
        }
        
        
        public void CalculateMana(float basicGridSize, int maxNumOfLevels)
        {
            _mana = basicGridSize / (PlayerLevel / (float)maxNumOfLevels);
        }
       
    }
}