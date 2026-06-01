using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Controls")]
    //connects to object want to shoot aka laser prefab
    public GameObject laserPrefab; 

    //where shoots from
    public Transform firePoint;     

    [Header("Controls")]

    //spacebar is shoot key
    public KeyCode shootKey = KeyCode.Space; 

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //spawns clone of your laser prefab at the shooting position
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Laser Fired!");
    }
}
