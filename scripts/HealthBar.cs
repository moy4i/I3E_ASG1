using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Assign this in the Inspector

    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }
    
}
