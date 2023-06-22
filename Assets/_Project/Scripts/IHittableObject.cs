using EnemyLogic;
using UnityEngine;

namespace HittableObjects
{
    public interface IHittableObject
    {
        public void SpawnImpactParticles(RaycastHit hit);
    }
}





