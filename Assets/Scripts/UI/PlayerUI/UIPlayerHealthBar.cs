using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    void OnEnable()
    {
        GameEvents.OnPlayerHealthChanged += UpdateHealth;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerHealthChanged -= UpdateHealth;
    }

    void UpdateHealth(float current, float max)
    {
        healthSlider.value = current / max;
    }
}
