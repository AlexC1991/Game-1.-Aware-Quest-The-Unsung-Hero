using System;
using System.Threading;
using UnityEngine;

namespace AlexzanderCowell
{

    public class CharacterMovementScript : MonoBehaviour
    {
        [Header("Inspector Changes")]
        [Range(-50,50)]
        [SerializeField] private float gravitySlider;
        [Range(0,30)]
        private float walkSpeed = 6;
        [SerializeField] private float downValue, upValue;
        
        [Header("Internal Edits")]
        private Camera _playerCamera;
        private CharacterController _controller;
        private bool _runFaster;
        private float _mouseSensitivityY;
        private float _mouseSensitivityX;
        private float _normalWalkSpeed;
        private float _mouseXposition,
            _moveHorizontal,
            _moveVertical,
            _mouseYposition;
        private Vector3 _moveDirection;
        private Animator _playersAnimation;
        private float _timeElapsed = 0;
        private float _duration = 3;
        private float idleTimer = 2;
        private float idleResetTimer;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _playerCamera = Camera.main;
            _playersAnimation = GetComponent<Animator>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false;
            _mouseSensitivityY = 0.7f;
            _mouseSensitivityX = 1;
            /*_normalWalkSpeed = walkSpeed;*/
            _runFaster = false;
            idleResetTimer = idleTimer;
        }

        private void FixedUpdate()
        {
            CharacterGravity();
            CharacterMovementBase();
        }

        private void Update()
        {
            /*if (_timeElapsed < _duration)
            {
                float t = _timeElapsed / _duration;
                walkSpeed = Mathf.Lerp(0, 8, t);
                _timeElapsed += Time.deltaTime;
            }
            else
            {
                walkSpeed = 5;
            }*/
            
            Debug.Log("Idle Timer " + idleTimer);
            
            
            /*Debug.Log("Horizontal " + _moveHorizontal);
            Debug.Log("Vertical " + _moveVertical);*/
            
            if (_moveHorizontal > 0 || _moveVertical > 0 || _moveHorizontal < 0)
            {
                _playersAnimation.SetBool("IsWalking", true);
            }
            else
            {
                _playersAnimation.SetBool("IsWalking", false);
            }

            if (_moveVertical < 0)
            {
                _playersAnimation.SetBool("IsWalkingBackwards", true);
            }
            else
            {
                _playersAnimation.SetBool("IsWalkingBackwards", false);
            }

            if (_moveHorizontal > 0 || _moveVertical > 0)
            {
                idleTimer -= 0.5f * Time.deltaTime;
            }
            
            if (idleTimer < 0.2f && _moveHorizontal > 0)
            {
                idleTimer = 0;
                _playersAnimation.SetBool("SleepAnimation", true);
            }
            else
            {
                _playersAnimation.SetBool("SleepAnimation", false);
                idleTimer = idleResetTimer;
            }
        }

        private void CharacterMovementBase()
        {
            
            _mouseXposition += Input.GetAxis("Mouse X") * _mouseSensitivityX;
            _mouseYposition -= Input.GetAxis("Mouse Y") * _mouseSensitivityY;
            _mouseYposition = Mathf.Clamp(_mouseYposition, downValue, upValue);
            _moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal movement of the character.
            _moveVertical = Input.GetAxis("Vertical"); // Gets the vertical movement of the character.
            
            transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
            _playerCamera.transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
            Vector3 movement = new Vector3(_moveHorizontal, 0f, _moveVertical); // Allows the character to move forwards and backwards & left & right.
            movement = transform.TransformDirection(movement) * walkSpeed; // Gives the character movement speed.
            _controller.Move((movement + _moveDirection) * Time.deltaTime); // Gets all the movement variables and moves the character.
        }

        private void CharacterGravity()
        {
            _moveDirection.y += gravitySlider * Time.deltaTime;
            // Move the character controller with gravity
            _controller.Move(_moveDirection * Time.deltaTime);
        }

        
    }
}
