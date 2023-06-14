using Player.InputService;
using Player.WeaponSystem;
using UnityEngine;

namespace Player
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

