using System;
using UnityEngine;

namespace Health
{
    public abstract class HealthBase : MonoBehaviour, IHealth
    {
        [SerializeField] private int _value;

        public int Value => _value;

        public event Action DamageTaken;

        public void TakeDamage(int damage)
        {
            _value -= damage;
            print(_value);

            DamageTaken?.Invoke();
        }
    }
}

