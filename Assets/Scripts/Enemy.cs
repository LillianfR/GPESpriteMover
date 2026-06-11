using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Base Enemy Settings")]
    public float maxHealth = 30f;

    protected float currentHealth;

    [Header("UI")]
    public HealthBar healthBar;

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        //initialize health bar
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

        Debug.Log(gameObject.name + " spawned with " + currentHealth + " HP.");
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log(gameObject.name + " took " + damageAmount + " damage. HP left: " + currentHealth);

        //update health bar when damaged
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " was destroyed.");
        Destroy(gameObject);
    }
}