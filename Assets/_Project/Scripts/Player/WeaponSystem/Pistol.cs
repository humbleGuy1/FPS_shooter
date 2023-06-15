using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class Pistol : Weapon
    {
        [SerializeField] private WeaponSO _pistolSritableObject;
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

            if(currentAmmo == 0)
                isEmpty = true;
        }

        private void Initialize()
        {
            maxCapacity = _pistolSritableObject.MaxCapacity;
            fireCooldown = _pistolSritableObject.FireCooldown;
            reloadingTime = _pistolSritableObject.ReloadingTime;
            currentAmmo = maxCapacity;
        }

        private IEnumerator ActivateEffect()
        {
            _shotEffect.SetActive(true);

            yield return new WaitForSeconds(0.05f);

            _shotEffect.SetActive(false);
        }
    }
}

