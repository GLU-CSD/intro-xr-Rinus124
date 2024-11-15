// gebruikt de assets van Unity zelf en de UI's van Unity
using UnityEngine;
using UnityEngine.UI;

//Start van het gehele script met de naam van het script zelf
public class HealthUI : MonoBehaviour
{
    //variabelen (public zijn in andere scripts zichtbaar en private niet)
    public string prefabTag = "magician_rio_unity";
    private Health healthScript;
    void Start()
    {

    }

    // functie die zich steeds herhaald
    void Update()
    {
        if (healthScript == null)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);

            if (spawnedPrefab != null)
            {
                healthScript = spawnedPrefab.GetComponent<Health>();
            }
        }
    }
    //als damage button wordt geklikt
    public void DamageButton()
    {
        if (healthScript != null)
        {
            healthScript.TakeDamage(10);
        }
    }
    //als Heal button wordt geklikt
    public void HealButton()
    {
        if (healthScript != null)
        {
            healthScript.RestoreHealth(10);
        }
    }
}

