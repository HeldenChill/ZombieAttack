using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public Action OnEnemyDie;
    public static LevelManager Inst;
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
