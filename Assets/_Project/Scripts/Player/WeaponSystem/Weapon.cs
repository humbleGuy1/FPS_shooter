using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponSO _weaponScriptableObject;

        private int _currentAmmo;
        private float _cooldownTimer;
        private float _reloadingTimer;

        public int MaxCapacity => _weaponScriptableObject.MaxCapacity;
        public float FireCooldown => _weaponScriptableObject.FireCooldown;
        public float ReloadTime => _weaponScriptableObject.ReloadTime;
        public int CurrentAmmo => _currentAmmo;
        public bool IsEmpty => _currentAmmo == 0;
        public bool NotReloading => _reloadingTimer <= 0;
        public bool CooldownFinished => _cooldownTimer <= 0;

        public void Initialize()
        {
            _currentAmmo = MaxCapacity;
        }

        public virtual void Fire()
        {
            _currentAmmo--;
            StartCoroutine(CountFireCooldown());
        }

        public void Reload()
        {
            _currentAmmo = MaxCapacity;
            StartCoroutine(StartReloading());
        }

        private IEnumerator CountFireCooldown()
        {
            _cooldownTimer = FireCooldown;

            while (_cooldownTimer > 0)
            {
                _cooldownTimer -= Time.deltaTime;

                yield return null;
            }
        }

        private IEnumerator StartReloading()
        {
            _reloadingTimer = ReloadTime;

            while (_reloadingTimer > 0)
            {
                _reloadingTimer -= Time.deltaTime;

                yield return null;
            }
        }
    }
}

