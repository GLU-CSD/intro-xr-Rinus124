using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private Health enemy1;


    void Update()
    {
        if (enemy1 != null && Time.time >= lastAttackTime + attackCooldown)
        {
            enemy1.TakeDamage(damageAmount);
            lastAttackTime = Time.time;
            Debug.Log(this.name + "Works!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy1 = collision.gameObject.GetComponent<Health>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy1 = null;
        }
    }
}
