using System;

namespace Health
{
    public interface IHealth
    {
        public int Value { get; }

        public void TakeDamage(int damage);

        public event Action DamageTaken;
    }
}

