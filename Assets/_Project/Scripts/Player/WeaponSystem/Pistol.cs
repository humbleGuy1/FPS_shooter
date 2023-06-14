using System.Collections;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponSO _weaponSritableObject;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _shotEffect;

        private int _maxAmmo;
        private int _currentAmmo;

        public int MaxAmmo => _maxAmmo;
        public int CurrentAmmo => _currentAmmo;

        private void Start()
        {
            Initialize();
        }

        public void Attack()
        {
            Ray ray = new Ray(_shootingPoint.position, transform.forward);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10f, Color.red);

            StartCoroutine(ActivateEffect());
            _currentAmmo--;
        }

        public void Reload()
        {
            print("Reloaded");
            _currentAmmo = _maxAmmo;
        }

        private void Initialize()
        {
            _maxAmmo = _weaponSritableObject.MaxAmmo;
            _currentAmmo = _maxAmmo;
        }

        private IEnumerator ActivateEffect()
        {
            _shotEffect.SetActive(true);

            yield return new WaitForSeconds(0.05f);

            _shotEffect.SetActive(false);
        }
    }
}

