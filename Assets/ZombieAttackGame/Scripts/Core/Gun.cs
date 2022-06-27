using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 100f;
    public float rateOfFire = 2;
    public Camera fpsCamera;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    Transform aimPoint;
    float counterTimeFire;
    void Start()
    {
        PrefabManager.Inst.CreatePool(bullet);
        transform.LookAt(aimPoint.position);

        counterTimeFire = 1 / rateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        counterTimeFire -= Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if((shootPoint.position - hit.point).magnitude > 2)
            {
                transform.LookAt(hit.point);
            }
            
        }
        else
        {
            transform.LookAt(aimPoint.position);
        }

        if (Input.GetButton("Fire1") && counterTimeFire <= 0)
        {
            Shoot();
            counterTimeFire = 1 / rateOfFire;
        }
        
        
    }

    private void Shoot()
    {
        
        GameObject newBullet = PrefabManager.Inst.PopFromPool(bullet.tag);
        newBullet.transform.position = shootPoint.position;
        newBullet.transform.rotation = transform.rotation;
        //Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
