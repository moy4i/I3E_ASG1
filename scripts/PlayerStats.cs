using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float maxHealth;

    private float currentHealth;
    public Transform respawnPoint; // Assign in Inspector
    public HealthBar healthBar; // Assign this in the Inspector
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }
    void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetSlider(currentHealth);
        transform.position = respawnPoint.position;
    }    
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10f); // Example damage for testing
        }
    }
}
