using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    private int maxHealth;
    private int currentHealth;
    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            if(value > 0)
            {
                maxHealth = value;
            }          
        }
    }
    
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            if(value >= 0 && value <= maxHealth)
            {
                currentHealth = value;
                healthBar.fillAmount = (float)currentHealth / maxHealth;
            }          
        }
    }
}
