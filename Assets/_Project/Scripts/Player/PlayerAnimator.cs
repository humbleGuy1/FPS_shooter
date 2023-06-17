using PlayerLogic.InputService;
using System.Collections;
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
        private const string ReloadTime = "ReloadTime";

        private readonly int FireHash = Animator.StringToHash(Fire);
        private readonly int SpeedHash = Animator.StringToHash(Speed);
        private readonly int ReloadHash = Animator.StringToHash(Reload);
        private readonly int ReloadTimeHash = Animator.StringToHash(ReloadTime);

        private void Update()
        {
            _animator.SetFloat(SpeedHash, _characterController.velocity.magnitude);
        }

        public void PlayFireAnimation() => PlayAnimation(FireHash);

        public void PlayReloadAnimation(float reloadTime) =>
            PlayAnimationForTime(ReloadHash, ReloadTimeHash, reloadTime);

        private void PlayAnimation(int hash) => _animator.Play(hash);

        private void PlayAnimationForTime(int animationHash, int motionParameterHash, float duration)
        {
            _animator.SetFloat(motionParameterHash, 0);
            _animator.Play(animationHash);
            StartCoroutine(LerpAnimation(duration));
        }

        private IEnumerator LerpAnimation(float duration)
        {
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                _animator.SetFloat(ReloadTimeHash, Mathf.Lerp(0, 1, elapsedTime / duration));

                yield return null;
            }
        }
    }
}

