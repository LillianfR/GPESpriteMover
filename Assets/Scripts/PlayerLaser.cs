using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [Header("Laser Settings")]
    public float speed = 10f;
    public float damageAmount = 20f;
    public float lifetime = 3f;

    private void Start()
    {
        //destroys the laser after 3 seconds if it misses and flies off-screen
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        //moves the laser upward every frame
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    //triggers when the laser hits something with a Collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // looking for enemy script on the object we hit
        Enemy enemy = collision.GetComponent<Enemy>();

        // if it has an Enemy component deal damage
        if (enemy != null)
        {
            //this calls the inherited takedamage function
            enemy.TakeDamage(damageAmount);

            //destroy the laser bullet so it doesnt pass through
            Destroy(gameObject); 
        }
    }
}
