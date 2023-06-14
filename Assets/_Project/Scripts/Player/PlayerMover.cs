using Player.InputService;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _walkSpeed = 1.15f;
        [SerializeField] private float _runSpeed = 4.0f;
        [SerializeField] private float _lookSpeed = 2.0f;
        [SerializeField] private float _lookXLimit = 60.0f;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField ]private CharacterController _characterController;

        private Vector3 _moveDirection = Vector3.zero;
        private float _rotationX = 0;
        private bool _canMove = true;

        private void Update()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = _canMove ? (_playerInput.IsRunning ? _runSpeed : _walkSpeed) * _playerInput.InputAxisY : 0;
            float curSpeedY = _canMove ? (_playerInput.IsRunning ? _runSpeed : _walkSpeed) * _playerInput.InputAxisX : 0;
            _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            _characterController.Move(_moveDirection * Time.deltaTime);

            if (_canMove)
            {
                _rotationX += -_playerInput.InputMouseY * _lookSpeed;
                _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);
                _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, _playerInput.InputMouseX * _lookSpeed, 0);
            }
        }
    }
}