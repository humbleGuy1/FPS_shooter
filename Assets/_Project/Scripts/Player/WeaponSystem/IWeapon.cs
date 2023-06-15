namespace PlayerLogic.WeaponSystem
{
    public interface IWeapon
    {
        public int MaxCapacity { get; }
        public int CurrentAmmo { get; }
        public float FireCooldown { get; }
        public float ReloadingTime { get; }
        public bool IsEmpty { get; }

        public void Initialize();
        public void Shoot();
        public void Reload();
    }
}

