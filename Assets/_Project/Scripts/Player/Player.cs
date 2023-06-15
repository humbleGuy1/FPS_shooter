using PlayerLogic.InputService;
using PlayerLogic.WeaponSystem;
using UnityEngine;

namespace PlayerLogic
{
    [SelectionBase]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private WeaponHandler _weaponHadnler;

        private void Update()
        {
            if (_playerInput.IsShooting)
            {
                _weaponHadnler.TryUseWeapon();
            }
        }
    }
}

