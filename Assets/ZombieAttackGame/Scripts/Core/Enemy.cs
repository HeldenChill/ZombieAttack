using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utilitys;

public class Enemy : MonoBehaviour,ITakeDamage
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    public Transform target;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    int maxHealth = 100;
    int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed + new Vector3(0,rb.velocity.y,0);
    }

    public void InitializeTakeDamage()
    {
        //NOTIFY:Set layer in Inspector
    }

    public int TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            LevelManager.Inst.OnEnemyDie();
            Destroy(gameObject);
        }
        return damage;
    }
}
