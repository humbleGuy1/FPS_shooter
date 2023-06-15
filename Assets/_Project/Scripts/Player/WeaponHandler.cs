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
            if (_currentWeapon.IsEmpty == false)
            {
                _currentWeapon.Shoot();
                _playerAnimator.PlayFireAnimation();
                WeaponUsed?.Invoke();
            }
        }

        public void ReloadWeapon()
        {
            if(_currentWeapon.CurrentAmmo < _currentWeapon.MaxCapacity)
            {
                _currentWeapon.Reload();
                _playerAnimator.PlayReloadAnimation();
                WeaponUsed?.Invoke();
            }
        }
    }
}



