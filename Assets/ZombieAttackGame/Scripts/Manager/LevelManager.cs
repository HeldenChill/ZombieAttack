using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public Action OnEnemyDie;
    [SerializeField]
    EnemyGenerator enemyGenerator;
    public static LevelManager Inst;

    public EnemyGenerator EnemyGenerator { get => enemyGenerator;}

    void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            return;
        }
        Destroy(gameObject);
    }

}
