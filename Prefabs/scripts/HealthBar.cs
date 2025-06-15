/*
* Author: Justin Tan
* Date: 13-6-2025
* Description: 	Updates and displays the player’s health visually in the UI
*/
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
