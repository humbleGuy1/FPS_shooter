using Player.Animation;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private IWeapon _currentWeapon;

        private void Start()
        {
            _currentWeapon = GetComponentInChildren<IWeapon>();
        }

        public void TryUseWeapon()
        {
            if (_currentWeapon.CurrentAmmo > 0)
            {
                _currentWeapon.Attack();
                _playerAnimator.PlayFireAnimation();
            }
            else
            {
                _currentWeapon.Reload();
            }
        }
    }
}



