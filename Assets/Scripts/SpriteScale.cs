using UnityEngine;

public class SpriteScale : MonoBehaviour
{
    private Transform tf;
    public float maxScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float axisValue = Input.GetAxis("scale");
    //"*" is multiply 
        float scaleAmount = axisValue * maxScale;
        tf.localScale += Vector3.one * scaleAmount;
    }
}
