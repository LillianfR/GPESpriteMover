using UnityEngine;

public class TargetHum : MonoBehaviour
{
    public Transform player;
    public AudioSource humSource;

    public float maxDistance = 20f;

    void Update()
    {
        if (player == null || humSource == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        float volume = 1 - (distance / maxDistance);

    }
}
