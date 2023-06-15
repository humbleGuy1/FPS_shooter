using UnityEngine;

namespace PlayerLogic.InputService
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private const string MouseY = "Mouse Y";
        private const string MouseX = "Mouse X";

        public float InputAxisY => Input.GetAxis(Vertical);
        public float InputAxisX => Input.GetAxis(Horizontal);
        public float InputMouseY => Input.GetAxis(MouseY);
        public float InputMouseX => Input.GetAxis(MouseX);
        public bool IsRunning => Input.GetKey(KeyCode.LeftShift);
        public bool IsShooting => Input.GetKeyDown(KeyCode.Mouse0);
        public bool IsReloading => Input.GetKeyDown(KeyCode.R);
    }
}

