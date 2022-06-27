using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIGamePlay : MonoBehaviour
    {
        [SerializeField]
        private HealthBar healthBar;

        private void Awake()
        {
            SetMaxHealth(100);
            SetCurrentHealth(50);
        }
        public void SetMaxHealth(int maxHealth)
        {
            healthBar.MaxHealth = maxHealth;
        }

        public void SetCurrentHealth(int health)
        {
            healthBar.CurrentHealth = health;
        }


        public void SetActive(bool p)
        {
            gameObject.SetActive(p);
        }
    }
}