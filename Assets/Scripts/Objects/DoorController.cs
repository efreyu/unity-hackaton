using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DoorController : MonoBehaviour
{
    private Collider2D m_Collider;
    private SpriteRenderer m_Renderer;
    public Sprite PositiveSpriteState;
    public Sprite NegativeSpriteState;
    public bool IsClose;

    private void Awake()
    {
        gameObject.AddComponent<FixZIndex>();
        if (m_Collider == null)
        {
            m_Collider = GetComponent<Collider2D>();
//            m_Collider.isTrigger = true;
        }

        if (m_Renderer == null)
        {
            m_Renderer = GetComponent<SpriteRenderer>();
        }
        
        Init(IsClose);
    }

    private void Init(bool isClose)
    {
        if (isClose)
        {
            m_Renderer.sprite = NegativeSpriteState;
        }
        else
        {
            m_Renderer.sprite = PositiveSpriteState;
        }
        m_Collider.enabled = isClose;
    }

    public void Toggle()
    {
        IsClose = !IsClose;
        Init(IsClose);
    }

    public void SetState(bool state)
    {
        IsClose = !state;
        Init(!state);
    }
}