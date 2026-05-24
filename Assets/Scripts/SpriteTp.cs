using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
        private Transform tf;
        public float maxHorizontalDistance = 5f;
        public float scalespeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //tp to random position on horizontal axis
        if (Input.GetButtonDown("teleport"))
        {
            Vector3 newPos = tf.position;
            newPos.x = Random.Range(-maxHorizontalDistance, maxHorizontalDistance);
            tf.position = newPos;
        }
    }
    
}
