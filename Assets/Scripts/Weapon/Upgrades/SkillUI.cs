using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text titleText;
    public Button selectButton;

    private SkillOption option;
    private SkillSelectionUI parent;

    public void Setup(SkillOption data, SkillSelectionUI ui)
    {
        option = data;
        parent = ui;

        icon.sprite = data.GetIcon();
        titleText.text = data.GetName();

        selectButton.onClick.AddListener(OnSelect);
    }

    void OnSelect()
    {
        parent.SelectSkill(option);
    }
}
