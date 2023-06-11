using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class SimplePlayerController : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _walkSpeed = 1.15f;
        [SerializeField] private float _runSpeed = 4.0f;
        [SerializeField] private float _lookSpeed = 2.0f;
        [SerializeField] private float _lookXLimit = 60.0f;
        [SerializeField] private float _gravity = 150.0f;

        CharacterController characterController;
        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;
        private bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        void Update()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (!characterController.isGrounded)
            {
                moveDirection.y -= _gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -_lookXLimit, _lookXLimit);
                _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
            }
        }
    }
}