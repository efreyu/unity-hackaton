using UnityEngine;
using UnityEngine.Rendering;

public class FixZIndex : MonoBehaviour
{
    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}