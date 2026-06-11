using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        //parent is the asteroid
        target = transform.parent;
    }

    void LateUpdate()
    {
        if (target == null) return;

        //keep position above asteroid
        transform.position = target.position + Vector3.up * 1.5f;

        //keep it from spinning
        transform.rotation = Quaternion.identity;
    }
}