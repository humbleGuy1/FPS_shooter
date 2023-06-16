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

        public void Shoot()
        {
            if (CanShoot())
            {
                _currentWeapon.Fire();
                _playerAnimator.PlayFireAnimation();
                WeaponUsed?.Invoke();
            }
        }

        public void ReloadWeapon()
        {
            if (CanReload())
            {
                _currentWeapon.Reload();
                _playerAnimator.PlayReloadAnimation();
                WeaponUsed?.Invoke();
            }
        }

        private void SetUpWeapon()
        {
            _currentWeapon = GetComponentInChildren<IWeapon>();
            _currentWeapon.Initialize();
            WeaponUsed?.Invoke();
        }

        private bool CanShoot() =>
            _currentWeapon.IsEmpty == false &&
            _currentWeapon.CooldownFinished &&
            _currentWeapon.NotReloading;

        private bool CanReload() => 
            _currentWeapon.CurrentAmmo < _currentWeapon.MaxCapacity;
    }
}



