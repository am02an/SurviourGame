using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionUI : MonoBehaviour
{
    public SkillSelectionManager selectionManager;
    public PlayerWeaponInventory inventory;
    public WeaponEvolutionManager evolutionManager;
    public WeaponSpawner weaponSpawner;
    public SkillUI cardPrefab;
    public Transform cardParent;

    private List<SkillUI> cards = new();
  
    private void OnEnable()
    {
        GenerateSkills();
    }

    void GenerateSkills()
    {
        ClearCards();

        var skills = selectionManager.GetRandomSkills();

        foreach (var skill in skills)
        {
            var card = Instantiate(cardPrefab, cardParent);
            card.Setup(skill, this);
            cards.Add(card);
        }
    }

    void ClearCards()
    {
        foreach (var c in cards)
            Destroy(c.gameObject);

        cards.Clear();
    }

    public void SelectSkill(SkillOption option)
    {
        if (option.isWeapon)
        {
            var weapon = option.weaponData.weaponType;
            inventory.ownedWeapons.Add(weapon);

            // Evolution Check
            var evolve = evolutionManager.TryEvolve(weapon);
            weaponSpawner.SpawnWeapon(weapon);
            if (evolve != null)
            {
                inventory.ownedWeapons.Remove(weapon);
                inventory.ownedWeapons.Add(evolve.Value);

                Debug.Log("Weapon Evolved  " + evolve.Value);
            }
        }
        else
        {
            inventory.ownedPassives.Add(option.passiveData.passiveType);
        }

        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
