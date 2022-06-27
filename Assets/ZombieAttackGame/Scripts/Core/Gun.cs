using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public int damage = 100;
    public float range = 100f;
    public float rateOfFire = 2;
    [SerializeField]
    GameObject bullet;
    public Transform shootPoint;
    float counterTimeFire;
    void Start()
    {
        PrefabManager.Inst.CreatePool(bullet);
        counterTimeFire = 1 / rateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        counterTimeFire -= Time.deltaTime;

        

        if (Input.GetButton("Fire1") && counterTimeFire <= 0)
        {
            Shoot();
            counterTimeFire = 1 / rateOfFire;
        }
        
        
    }

    private void Shoot()
    {
        
        GameObject newBullet = PrefabManager.Inst.PopFromPool(bullet.tag);
        newBullet.GetComponent<Bullet>().Damage = damage;
        newBullet.transform.position = shootPoint.position;
        newBullet.transform.rotation = transform.rotation;
        //Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
