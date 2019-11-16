using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteLightBehaviourScript : MonoBehaviour
{
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        render.shadowCastingMode = ShadowCastingMode.TwoSided;
    }
}