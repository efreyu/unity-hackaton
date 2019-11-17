using UnityEngine;
using UnityEngine.Rendering;

public class FixZIndex : MonoBehaviour
{
    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
//        transform.position.z = 0f;
        if (transform)
            transform.position.Set(transform.position.x, transform.position.y, .5f);
    }
}