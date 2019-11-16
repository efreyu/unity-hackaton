using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CreaturesController : MonoBehaviour
{
    public Animator animator;
    private bool _isDead;
    private bool _isInited = false;

    public bool IsDead
    {
        get => _isDead;
        set
        {
            if (_isDead)
            {
                _isDead = value;
            }
        }
    }

    private bool Init()
    {
        if (_isInited) return _isInited;
        
        animator = GetComponent<Animator>();
        _isInited = !_isInited;

        return _isInited;
    }

    private void Awake()
    {
        Init();
    }
}
