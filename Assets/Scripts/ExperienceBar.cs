using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI characterLevelText;

    public void UpdateExperienceSlider(int value, int maxValue) {
        slider.maxValue = maxValue;
        slider.value = value;
    }

    public void SetLevelText(int level) {
        characterLevelText.text = "LEVEL: " + level.ToString();
    }
}
