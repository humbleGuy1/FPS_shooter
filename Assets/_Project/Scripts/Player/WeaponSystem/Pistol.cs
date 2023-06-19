using System.Collections;
using UnityEngine;
using HittableObjects;

namespace PlayerLogic.WeaponSystem
{
    public class Pistol : Weapon
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _shotEffect;

        public override void Fire()
        {
            base.Fire();

            Ray ray = new Ray(_shootingPoint.position, transform.forward);
            //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out IHittableObject hittable))
                {
                    hittable.SpawnImpactParticles(hit);
                }
            }

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

