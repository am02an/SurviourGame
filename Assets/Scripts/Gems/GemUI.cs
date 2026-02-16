using UnityEngine;
using UnityEngine.UI;

public class GemUI : MonoBehaviour
{
    public Slider gemSlider;

    private void OnEnable()
    {
        GameEvents.OnPlayerCollectGem += UpdateSlider;
        GameEvents.OnPlayerLevelUp += ResetSlider;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerCollectGem -= UpdateSlider;
        GameEvents.OnPlayerLevelUp -= ResetSlider;
    }

    void UpdateSlider(int current, int required)
    {
        gemSlider.value = (float)current / required;
    }

    void ResetSlider()
    {
        gemSlider.value = 0;
    }
}
