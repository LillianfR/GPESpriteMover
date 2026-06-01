using UnityEngine;

//connects to enemy script to inherit health and damage functions
public class Asteroid : Enemy
{
    [Header("Asteroid Unique Physics")]
    public float minTumbleSpeed = 10f;
    public float maxTumbleSpeed = 50f;
    public float downwardSpeed = 2f;
    
    private Rigidbody2D rb;

    //override allows us to add asteroid physics 
    protected override void Start()
    {
        // the base (core)
        base.Start(); 

        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            //make astroid spin randomly
            float randomSpin = Random.Range(minTumbleSpeed, maxTumbleSpeed);
            rb.angularVelocity = randomSpin;
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + Vector2.down * downwardSpeed * Time.fixedDeltaTime);
        }
    }

    //handles crashing directly into the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //was used for debugging to see what we were colliding with
        //Debug.Log("The Asteroid trigger just overlapped with something named: " + collision.gameObject.name);

        //checks if the object we collided with is tagged as the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteLifeDeath player = collision.gameObject.GetComponent<SpriteLifeDeath>();
            
            if (player != null)
            {
                //damage to the player ship
                player.TakeDamage(10f); 
            }

            //replaced Die() with Destroy(gameObject) so crashing doesn't count as a victory point
            Destroy(gameObject); 
        }
    }

    //laser will dmg astroid
    protected override void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TargetDestroyed();
        }

        base.Die();
    }
}
