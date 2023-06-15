using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class Pistol : Weapon
    {
        [SerializeField] private WeaponSO _weaponSritableObject;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _shotEffect;

        private void Start()
        {
            Initialize();
        }

        public override void Shoot()
        {
            Ray ray = new Ray(_shootingPoint.position, transform.forward);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10f, Color.red);

            StartCoroutine(ActivateEffect());
            currentAmmo--;
        }

        private void Initialize()
        {
            maxAmmo = _weaponSritableObject.MaxAmmo;
            currentAmmo = maxAmmo;
            fireCooldown = _weaponSritableObject.FireCooldown;
        }

        private IEnumerator ActivateEffect()
        {
            _shotEffect.SetActive(true);

            yield return new WaitForSeconds(0.05f);

            _shotEffect.SetActive(false);
        }
    }
}

