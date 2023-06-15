using PlayerLogic.InputService;
using UnityEngine;

namespace PlayerLogic.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CharacterController _characterController;

        private const string Fire = "Fire";
        private const string Speed = "Speed";
        private const string Reload = "Reload";

        private readonly int FireHash = Animator.StringToHash(Fire);
        private readonly int SpeedHash = Animator.StringToHash(Speed);
        private readonly int ReloadHash = Animator.StringToHash(Reload);

        private void Update() => 
            _animator.SetFloat(SpeedHash, _characterController.velocity.magnitude);

        public void PlayFireAnimation() => PlayAnimation(FireHash);

        public void PlayReloadAnimation() => PlayAnimation(ReloadHash);

        private void PlayAnimation(int hash) => _animator.Play(hash);
    }
}

