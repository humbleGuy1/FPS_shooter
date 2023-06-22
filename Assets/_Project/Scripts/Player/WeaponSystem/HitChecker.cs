using EnemyLogic;
using HittableObjects;
using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public class HitChecker
    {
        private readonly int _layerMaskToIgnore = ~(1 << LayerMask.NameToLayer(Enemy));

        private const string Enemy = "Enemy";

        public void HitEnemy(Ray ray, int damage)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemy.Health.TakeDamage(damage);
                }
            }
        }

        public void HitHittableObject(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMaskToIgnore))
            {
                if (hit.collider.gameObject.TryGetComponent(out IHittable hittable))
                {
                    hittable.SpawnImpactParticles(hit);
                }
            }
        }
    }
}

