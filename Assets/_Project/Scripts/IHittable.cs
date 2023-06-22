using EnemyLogic;
using UnityEngine;

namespace HittableObjects
{
    public interface IHittable
    {
        public void SpawnImpactParticles(RaycastHit hit);
    }
}





