using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public SkillDatabase database;
    public PlayerWeaponInventory inventory;

    public int selectionCount = 3;

    public List<SkillOption> GetRandomSkills()
    {
        var available = database.GetAllSkills();
        List<SkillOption> result = new();

        while (result.Count < selectionCount && available.Count > 0)
        {
            //int index = Random.Range(0, available.Count);
            int index =0;
            var skill = available[index];

            available.RemoveAt(index);

            // Prevent duplicate weapon
            if (skill.isWeapon && inventory.HasWeapon(skill.weaponData.weaponType))
                continue;

            result.Add(skill);
        }

        return result;
    }
}
