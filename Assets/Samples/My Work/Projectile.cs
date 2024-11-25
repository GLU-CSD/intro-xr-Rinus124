
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;
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
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
           Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }

    void TakeDamage(GameObject enemy, int damage)
    {
        healthScript = enemy.GetComponent<Health>();
        healthScript.TakeDamage(damage);
    }
}
