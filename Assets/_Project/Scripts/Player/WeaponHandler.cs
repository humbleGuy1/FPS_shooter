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

        public void UseWeapon()
        {
            if (_currentWeapon.CurrentAmmo > 0)
            {
                _currentWeapon.Shoot();
                _playerAnimator.PlayFireAnimation();
            }
            else if (_currentWeapon.CurrentAmmo < _currentWeapon.MaxAmmo)
            {
                _currentWeapon.Reload();
                _playerAnimator.PlayReloadAnimation();
            }

            WeaponUsed?.Invoke();
        }
    }
}



