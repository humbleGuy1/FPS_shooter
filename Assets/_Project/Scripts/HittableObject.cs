using UnityEngine;

namespace HittableObjects
{
    public class HittableObject : MonoBehaviour, IHittableObject
    {
        [SerializeField] private ObjectType _type;

        public ObjectType Type => _type;

        public void OnHit()
        {
            print(gameObject.name);
        }
    }
}





