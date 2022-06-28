using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class PlayerData : ScriptableObject
{
    private int maxHP = 0;
    private int currentHP = 0;
    private int kill = 0;
    private int wave = 0;

    public int MaxHP { 
        get => maxHP;
        set
        {
            if(value > 0)
            {
                maxHP = value;
                UIManager.Inst.UiGameplay.SetMaxHealth(currentHP);
                CurrentHP = maxHP;

            }
        }
    }
    public int CurrentHP { 
        get => currentHP; 
        set
        {
            currentHP = Mathf.Clamp(value, 0, maxHP);
            UIManager.Inst.UiGameplay.SetCurrentHealth(currentHP);
        }
    }
    public int Kill { 
        get => kill;
        set
        {
            kill = value;
            UIManager.Inst.UIInformation.SetData(UIInformation.TypeInfo.Kill, kill);
        }
    }
    public int Wave { 
        get => wave; 
        set
        {
            wave = value;
            UIManager.Inst.UIInformation.SetData(UIInformation.TypeInfo.Wave, wave);
        }
    }
}
