using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Skill Database")]
public class SkillDatabase : ScriptableObject
{
    public List<ActiveWeaponData> weapons;
    public List<PassiveBoostData> passives;

    public List<SkillOption> GetAllSkills()
    {
        List<SkillOption> all = new();

        foreach (var w in weapons)
        {
            all.Add(new SkillOption
            {
                isWeapon = true,
                weaponData = w
            });
        }

        foreach (var p in passives)
        {
            all.Add(new SkillOption
            {
                isWeapon = false,
                passiveData = p
            });
        }

        return all;
    }
}
[System.Serializable]
public class SkillOption
{
    public bool isWeapon;

    public ActiveWeaponData weaponData;
    public PassiveBoostData passiveData;

    public string GetName()
    {
        return isWeapon ? weaponData.weaponName : passiveData.passiveName;
    }

    public Sprite GetIcon()
    {
        return isWeapon ? weaponData.icon : passiveData.icon;
    }
}
