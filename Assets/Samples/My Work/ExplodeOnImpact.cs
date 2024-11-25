
using UnityEngine;
using UnityEngine.AI;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public float maxHealth = 100f;
    public float currentHealth;
    private Health healthScript = null;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
            TakeDamage(collision.gameObject, 50);
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

                if (nearbyObject.gameObject.CompareTag("Enemy"))
                {
                    TakeDamage(nearbyObject.gameObject, 10);
                }
            }
        }
    }

    void TakeDamage(GameObject enemy, int damage)
    {
        healthScript = enemy.GetComponent<Health>();
        healthScript.TakeDamage(damage);
    }

}

