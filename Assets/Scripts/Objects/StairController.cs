using System;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class StairController : UsableObject
{
    private Collider2D m_Collider;
//    private SpriteRenderer m_Renderer;


    private void Awake()
    {
//        gameObject.AddComponent<FixZIndex>();
        if (m_Collider == null)
        {
            m_Collider = GetComponent<Collider2D>();
            m_Collider.isTrigger = true;
        }
    }

    public void TryUse()
    {
//        Debug.Log("On fucking stair");
    }
    
}