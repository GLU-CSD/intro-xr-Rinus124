using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private Health baseHealth;


    void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + attackCooldown)
        {
            baseHealth.TakeDamage(damageAmount);
            lastAttackTime = Time.time;
            Debug.Log(this.name + "attacked the base!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BaseAttack"))
        {
            baseHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BaseAttack"))
        {
            baseHealth = null;
        }
    }
}
