using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponSO weaponSriptableObject;

        private int _maxCapacity;
        private int _currentAmmo;
        private float _fireCooldown;
        private float _reloadingTime;
        private float _cooldownTimer;

        public int MaxCapacity => _maxCapacity;
        public int CurrentAmmo => _currentAmmo;
        public float FireCooldown => _fireCooldown;
        public float ReloadingTime => _reloadingTime;
        public float CooldownTimer => _cooldownTimer;
        public bool IsEmpty => _currentAmmo == 0;

        public void Initialize()
        {
            _maxCapacity = weaponSriptableObject.MaxCapacity;
            _fireCooldown = weaponSriptableObject.FireCooldown;
            _reloadingTime = weaponSriptableObject.ReloadingTime;
            _currentAmmo = _maxCapacity;
        }

        public virtual void Fire()
        {
            _currentAmmo--;
            StartCoroutine(CountCooldown());
        }

        public void Reload()
        {
            _currentAmmo = _maxCapacity;
        }

        private IEnumerator CountCooldown()
        {
            _cooldownTimer = _fireCooldown;

            while (_cooldownTimer > 0)
            {
                _cooldownTimer -= Time.deltaTime;

                yield return null;
            }
        }
    }
}

