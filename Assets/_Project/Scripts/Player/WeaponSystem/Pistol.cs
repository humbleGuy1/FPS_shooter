using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class Pistol : Weapon
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _shotEffect;

        public override void Initialize()
        {
            maxCapacity = weaponSriptableObject.MaxCapacity;
            fireCooldown = weaponSriptableObject.FireCooldown;
            reloadingTime = weaponSriptableObject.ReloadingTime;
            currentAmmo = maxCapacity;
        }

        public override void Shoot()
        {
            Ray ray = new Ray(_shootingPoint.position, transform.forward);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10f, Color.red);

            StartCoroutine(ActivateEffect());
            currentAmmo--;

            if(currentAmmo == 0)
                isEmpty = true;
        }

        private IEnumerator ActivateEffect()
        {
            _shotEffect.SetActive(true);

            yield return new WaitForSeconds(0.05f);

            _shotEffect.SetActive(false);
        }
    }
}

