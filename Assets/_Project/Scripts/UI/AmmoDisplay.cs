using TMPro;
using UnityEngine;
using PlayerLogic.WeaponSystem;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoCountText;
    [SerializeField] private WeaponHandler _weaponHandler;

    private void OnEnable() => _weaponHandler.WeaponUsed += UpdateView;

    private void OnDisable() => _weaponHandler.WeaponUsed -= UpdateView;

    private void UpdateView() => 
        _ammoCountText.text = $"{_weaponHandler.CurrentWeapon.CurrentAmmo} / {_weaponHandler.CurrentWeapon.MaxAmmo}";
}
