using UnityEngine;

namespace HittableObjects
{
    public class HittableObject : MonoBehaviour, IHittableObject
    {
        [SerializeField] private ParticleSystem _hitEffectPrefab;

        public void SpawnImpactParticles(RaycastHit hit)
        {
            ParticleSystem effect = Instantiate(_hitEffectPrefab, hit.point, Quaternion.identity);
            effect.transform.rotation = Quaternion.FromToRotation(effect.transform.forward, hit.normal)
                * effect.transform.rotation; ;
        }
    }
}




