using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponData _weaponData;

        private int _currentAmmo;
        private float _cooldownTimer;
        private float _reloadingTimer;
        private HitChecker _hitChecker;

        private Coroutine _fireCoroutine;

        public int MaxCapacity => _weaponData.MaxCapacity;
        public int Damage => _weaponData.Damage;
        public float FireCooldown => _weaponData.FireCooldown;
        public float ReloadTime => _weaponData.ReloadTime;
        public int CurrentAmmo => _currentAmmo;
        public bool IsEmpty => _currentAmmo == 0;
        public bool CooldownFinished => _cooldownTimer <= 0;
        public bool NotReloading => _reloadingTimer <= 0;
        public HitChecker HitChecker => _hitChecker;

        public void Initialize()
        {
            _currentAmmo = MaxCapacity;
            _hitChecker = new HitChecker();
        }

        public virtual void Fire()
        {
            if(_fireCoroutine is not null)
                StopCoroutine(_fireCoroutine);

            _currentAmmo--;
            _fireCoroutine = StartCoroutine(CountFireCooldown());
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

