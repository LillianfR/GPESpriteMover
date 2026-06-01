using UnityEngine;

public class Enemy : MonoBehaviour
{
    //!!dont attach, just script for health and destruction!!

    [Header("Base Enemy Settings")]
    public float maxHealth = 30f;
    
    //protected means child classes like Asteroid can read and modify this
    protected float currentHealth; 

    //protected virtual lets child classes run their own start code
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(gameObject.name + " spawned with " + currentHealth + " HP.");
    }

    //calling public function from player lasers 
    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. HP left: " + currentHealth);

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
