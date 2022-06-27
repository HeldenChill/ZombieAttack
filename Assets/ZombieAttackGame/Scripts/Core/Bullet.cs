using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitys;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float lifeTime = 5f;
    [SerializeField]
    int damage = 10;

    public int Damage
    {
        get => damage;
        set
        {
            damage = value;
        }
    }
    float countTime;

    bool isCollided = false; 
    RaycastHit hit = default;

    private void OnEnable()
    {
        countTime = lifeTime;
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(isCollided)
        {
            Collide(hit.collider);
        }

        isCollided = Physics.Raycast(ray, out hit, speed * Time.deltaTime);

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        if(countTime <= 0)
        {
            PrefabManager.Inst.PushToPool(gameObject);
        }
        else
        {
            countTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collide(other);
    }

    private void Collide(Collider other)
    {
        if (!isCollided)
            return;

        isCollided = false;
        hit = default;

        //Do Something under here
        if ((int)(Mathf.Pow(2, other.gameObject.layer)) == LayerMask.GetMask("CanTakeDamage"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Damage);
            PrefabManager.Inst.PushToPool(gameObject);
        }
    }
}
