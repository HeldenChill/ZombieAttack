using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Transform target;
    [SerializeField]
    float speed = 5;
    void Start()
    {
        
    }
    private void Update()
    {
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }
}
