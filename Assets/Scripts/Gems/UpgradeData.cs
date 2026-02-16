using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/New Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public Sprite icon;
    public UpgradeType upgradeType;

    public float value;
}

public enum UpgradeType
{
    AddWeapon,
    IncreaseDamage,
    IncreaseFireRate,
    IncreaseMoveSpeed
}
