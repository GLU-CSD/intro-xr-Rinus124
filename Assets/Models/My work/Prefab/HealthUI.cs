using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public string prefabTag = "magician_rio_unity";
    private Health healthScript;
    void Start()
    {

    }

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
    public void DamageButton()
    {
        if (healthScript != null)
        {
            healthScript.TakeDamage(10);
        }
    }

    public void HealButton()
    {
        if (healthScript != null)
        {
            healthScript.RestoreHealth(10);
        }
    }
}

