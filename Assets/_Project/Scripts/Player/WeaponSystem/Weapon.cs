using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected int maxAmmo;
        protected int currentAmmo;
        protected float fireCooldown;

        public int MaxAmmo => maxAmmo;
        public int CurrentAmmo => currentAmmo;
        public float FireCooldown => fireCooldown;

        public abstract void Shoot();

        public void Reload() => currentAmmo = maxAmmo;
    }
}

