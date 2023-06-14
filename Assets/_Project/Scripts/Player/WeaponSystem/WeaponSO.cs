using UnityEngine;

namespace Player.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 1)]
    public class WeaponSO : ScriptableObject
    {
        [field: SerializeField] public int MaxAmmo { get; private set; }

    }
}
