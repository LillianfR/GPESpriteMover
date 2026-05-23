using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    //Declare our variables here
    public SpriteRenderer ourRenderThing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            ourRenderThing = GetComponent<SpriteRenderer>();
        //color change insruction goes here
        //change the color prop of the SpriteRender comopnents to green
        if (ourRenderThing != null)
    {
            ourRenderThing.color = Color.green;
    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
