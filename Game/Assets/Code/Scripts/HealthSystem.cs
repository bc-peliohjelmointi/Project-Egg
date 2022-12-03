using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem Instance;

    [SerializeField]
    private Slider healthBar;
    public float health;
    public float maxHealth = 100.0f;
    public bool isDead = false;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        Debug.Log(health);
        healthBar.value = health;
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        healthBar.value = health;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // healthBar.maxValue = maxHealth;
        // healthBar.value = maxHealth;
        health = maxHealth;
    }
}
