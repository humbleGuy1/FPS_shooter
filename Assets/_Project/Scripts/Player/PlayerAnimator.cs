using Player.InputService;
using UnityEngine;

namespace Player.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CharacterController _characterController;

        private const string Fire = "Fire";
        private const string Speed = "Speed";

        private readonly int FireHash = Animator.StringToHash(Fire);
        private readonly int SpeedHash = Animator.StringToHash(Speed);

        private void Update()
        {
            if (_playerInput.IsShooting)
            {
                PlayAnimation(FireHash);
            }

            _animator.SetFloat(SpeedHash, _characterController.velocity.magnitude);
        }

        private void PlayAnimation(int hash)
        {
            _animator.Play(hash);
        }
    }
}

