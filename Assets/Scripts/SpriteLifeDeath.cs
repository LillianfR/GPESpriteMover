using UnityEngine;

public class SpriteLifeDeath : MonoBehaviour
{
    //header allows visual organization of variables in the inspector!!!!
    [Header("Health Settings")]
    public float maxHealth = 50f;
    private float currentHealth;
    private bool isDead = false;

    [Header("Respawn Settings")]
    private Vector3 checkpointPosition;
    //respawn delay allows for a delay before the player respawns after death, can be set 
    public float respawnDelay = 2f;

    private void Start()
    {
        currentHealth = maxHealth;
        // sets spawn point as the first checkpoint
        checkpointPosition = transform.position; 
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;
        Debug.Log("Player Health: " + currentHealth);
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player Died!");

        //disables movement so player cannot move while dead
        if (GetComponent<Movement>() != null)
        {
            GetComponent<Movement>().enabled = false;
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerDied();
        }
    }
}
