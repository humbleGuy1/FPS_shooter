using UnityEngine;

namespace PlayerLogic.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 1)]
    public class WeaponSO : ScriptableObject
    {
        [field: SerializeField, Min(0)] public int MaxAmmo { get; private set; }
        [field: SerializeField, Min(0)] public float FireCooldown { get; private set; }

    }
}
