using PlayerLogic.Animation;
using System;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private IWeapon _currentWeapon;

        public event Action WeaponUsed;

        public IWeapon CurrentWeapon => _currentWeapon;

        private void Start()
        {
            _currentWeapon = GetComponentInChildren<IWeapon>();
            WeaponUsed?.Invoke();
        }

        public void TryUseWeapon()
        {
            if (_currentWeapon.CurrentAmmo > 0)
            {
                _currentWeapon.Attack();
                _playerAnimator.PlayFireAnimation();
            }
            else
            {
                _currentWeapon.Reload();
            }

            WeaponUsed?.Invoke();
        }
    }
}



