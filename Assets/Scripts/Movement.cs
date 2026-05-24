using UnityEngine;

public class Movement : MonoBehaviour
{
    // start not needed for this script 

    public int speed =7;

    // Update is called once per frame
    void Update()
    //connecting to the project settings input manager, using the horizontal and vertical axis to move the player in the x and z direction respectively. multiplying by speed and time.deltaTime to make the movement smooth and frame rate independent.
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // vertical in y slot(middle) to move up and down, horizontal in x slot to move left and right, z slot is 0 because we are not moving in that direction
        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        //applying the movement
        transform.position += direction * speed * Time.deltaTime;

    }
}
