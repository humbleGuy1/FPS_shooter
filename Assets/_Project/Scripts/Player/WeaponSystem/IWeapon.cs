namespace PlayerLogic.WeaponSystem
{
    public interface IWeapon
    {
        public int MaxAmmo { get; }
        public int CurrentAmmo { get; }
        public float FireCooldown { get; }

        public void Shoot();
        public void Reload();
    }
}

