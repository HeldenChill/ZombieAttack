using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    float lifeTime = 5f;
    float countTime;

    private void OnEnable()
    {
        countTime = lifeTime;
    }
    void Update()
    {
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
}
