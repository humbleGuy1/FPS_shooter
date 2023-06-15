namespace PlayerLogic.WeaponSystem
{
    public interface IWeapon
    {
        public int MaxAmmo { get; }
        public int CurrentAmmo { get; }

        public void Attack();
        public void Reload();
    }
}

