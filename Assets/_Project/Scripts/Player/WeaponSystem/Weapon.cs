using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected int maxCapacity;
        protected int currentAmmo;
        protected float fireCooldown;
        protected float reloadingTime;
        protected bool isEmpty;

        public int MaxCapacity => maxCapacity;
        public int CurrentAmmo => currentAmmo;
        public float FireCooldown => fireCooldown;
        public float ReloadingTime => reloadingTime;
        public bool IsEmpty => isEmpty;

        public abstract void Shoot();

        public void Reload()
        {
            currentAmmo = maxCapacity;
            isEmpty = false;
        }
    }
}

