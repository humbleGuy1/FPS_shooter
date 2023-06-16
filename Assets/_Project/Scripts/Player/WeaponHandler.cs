using PlayerLogic.Animation;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private PlayerAnimator _playerAnimator;

        private IWeapon _currentWeapon;

        public event Action WeaponUsed;

        public IWeapon CurrentWeapon => _currentWeapon;

        private void Start()
        {
            SetUpWeapon();
        }

        public void UseWeapon()
        {
            if (_currentWeapon.IsEmpty || _currentWeapon.CooldownTimer > 0)
                return;

            _currentWeapon.Shoot();
            _playerAnimator.PlayFireAnimation();
            WeaponUsed?.Invoke();
        }

        public void ReloadWeapon()
        {
            if (_currentWeapon.CurrentAmmo >= _currentWeapon.MaxCapacity)
                return;

            _currentWeapon.Reload();
            _playerAnimator.PlayReloadAnimation();
            WeaponUsed?.Invoke();
        }

        private void SetUpWeapon()
        {
            _currentWeapon = GetComponentInChildren<IWeapon>();
            _currentWeapon.Initialize();
            WeaponUsed?.Invoke();
        }
    }
}



