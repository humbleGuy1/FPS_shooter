using EnemyLogic.Health;
using UnityEngine;

namespace EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        public EnemyHealth Health => _health;
    }
}

