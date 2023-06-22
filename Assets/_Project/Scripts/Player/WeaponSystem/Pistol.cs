using System.Collections;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class Pistol : Weapon
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _shotEffect;

        private Ray _ray;

        public override void Fire()
        {
            base.Fire();

            _ray = new(_shootingPoint.position, transform.forward);

            HitChecker.HitEnemy(_ray, Damage);
            HitChecker.HitHittableObject(_ray);

            StartCoroutine(ActivateEffect());
        }

        private IEnumerator ActivateEffect()
        {
            _shotEffect.SetActive(true);

            yield return new WaitForSeconds(0.05f);

            _shotEffect.SetActive(false);
        }
    }
}

