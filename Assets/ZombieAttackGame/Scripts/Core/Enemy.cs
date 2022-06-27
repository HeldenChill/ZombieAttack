using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitys;

public class Enemy : MonoBehaviour,ITakeDamage
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Transform target;
    [SerializeField]
    float speed = 5;
    
    private void Update()
    {
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    public void InitializeTakeDamage()
    {
        //NOTIFY:Set layer in Inspector
    }

    public int TakeDamage(int damage)
    {
        Debug.Log("Enemy Take Damage");
        return 0;
    }
}
