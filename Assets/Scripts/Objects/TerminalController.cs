using System;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class TerminalController : UsableObject
{
    private Collider2D m_Collider;
    private SpriteRenderer m_Renderer;
    public bool IsActived;
    public bool IsBroken;
    public Transform WhatCanBeActivated;
    private DoorController _door;
    public Sprite PositiveSpriteState;
    public Sprite NegativeSpriteState;
    public Sprite BrokenSpriteState;
    

    private void Awake()
    {
        gameObject.AddComponent<FixZIndex>();
        if (m_Collider == null)
        {
            m_Collider = GetComponent<Collider2D>();
            m_Collider.isTrigger = true;
        }

        if (m_Renderer == null)
        {
            m_Renderer = GetComponent<SpriteRenderer>();
        }
        
        Init();
    }

    private void Init()
    {
        if (WhatCanBeActivated != null && _door == null)
        {
            _door = WhatCanBeActivated.GetComponent<DoorController>();
        }
        if (IsBroken)
        {
            m_Renderer.sprite = BrokenSpriteState;
        } 
        else if (CanBeUse())
        {
            if (IsActived)
            {
                m_Renderer.sprite = PositiveSpriteState;
                IsUsableObject = true;
                _door.SetState(true);
            }
            else
            {
                m_Renderer.sprite = NegativeSpriteState;
                _door.SetState(false);
            }
        }
        else
        {
            m_Renderer.sprite = NegativeSpriteState;
            _door.SetState(false);
        }
    }

    public void TryUse()
    {
        Debug.Log("USE!!!!!");
        if (CanBeUse())
        {
            IsActived = !IsActived;
            _door.Toggle();
            Init();
        }
    }

    private bool CanBeUse()
    {
        return WhatCanBeActivated != null && !IsBroken;
    }
    
}