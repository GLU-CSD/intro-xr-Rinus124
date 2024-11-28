// gebruikt de assets van Unity zelf en de UI's van Unity
using UnityEngine;
using UnityEngine.UI;

//Start van het gehele script met de naam van het script zelf
public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image Healthbarfill;

    // functie om de Healthbar te updaten wanneer er op een button wordt geklikt
    void UpdateHealthbar()
    {
        Healthbarfill.fillAmount = currentHealth / maxHealth;
    }

    //Het begin van het script (dit gebeurd als aller eerst)
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthbar();
    }

    //wanneer er op de damage button wordt geklikt (public functie dus die kan worden terug gevonden)
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthbar();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    //wanneer er op de Health button wordt geklikt (public functie dus die kan worden terug gevonden)
    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthbar();
    }

    public void Death()
    {
       Destroy(gameObject, 0.1f);
    }
}
