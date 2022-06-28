using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float rateOfSpawn = 2f;
    float timeCounter;

    bool isStartSpawn = false;

    public bool IsStartSpawn { 
        get => isStartSpawn; 
        set => isStartSpawn = value; 
    }

    private void Awake()
    {
        timeCounter = 1 / rateOfSpawn;
    }
    void Start()
    {
        PrefabManager.Inst.CreatePool(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStartSpawn)
            return;

        timeCounter -= Time.deltaTime;
        if(timeCounter <= 0)
        {
            SpawnEnemy();
            timeCounter = 1 / rateOfSpawn;
        }
    }

   
    Vector3 GetRandomPosition()
    {
        float posX;
        float posZ;
        int value2;
        int value1 = Random.Range(0, 2);
        if(value1 == 0)
        {
            posX = Random.Range(-40, 40);
            value2 = Random.Range(0, 2);
            if(value2 == 0)
            {
                posZ = Random.Range(30, 50);
            }
            else
            {
                posZ = Random.Range(-50, -30);
            }
        }
        else
        {
            posZ = Random.Range(-40, 40);
            value2 = Random.Range(0, 2);
            if (value2 == 0)
            {
                posX = Random.Range(30, 50);
            }
            else
            {
                posX = Random.Range(-50, -30);
            }
        }
        return new Vector3(posX, 10, posZ);
    }
    void SpawnEnemy()
    {
        Vector3 pos = GetRandomPosition();
        GameObject newEnemy = PrefabManager.Inst.PopFromPool(enemy.tag);
        newEnemy.GetComponent<Enemy>().target = GameManager.Inst.Player;
        newEnemy.transform.localPosition = pos;
    }
}
