
using UnityEngine;
using UnityEngine.UI;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public float maxHealth = 100f;
    public float currentHealth;
    public Image Healthbarfill;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthbar();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    } 
    
    //!!!!
    void HealthImpact(float amount)
    {
        GetComponent<Health>();
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthbar();
    }
    void UpdateHealthbar()
    {
        Healthbarfill.fillAmount = currentHealth / maxHealth;
    }
}
