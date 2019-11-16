using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    private bool _isJumpung = false;

    private bool _isUsing = false;
    public bool IsUsing
    {
        get => _isUsing;
        set
        {
            if (!value || _isMoving) return;
            _isUsing = value;
            animator.SetBool("IsUsing", value);
            //TODO проверка скорости анимации
            StartCoroutine (
                WaitAndDo(.5f, ()=>{
                    Debug.Log("IsUsing");
                    _isUsing = false;
                    animator.SetBool("IsUsing", _isUsing);
                })
            );
        }
    }

    private bool _itWasFalling = false;
    
    private bool _isAttention = false;
    public bool IsAttention
    {
        get => _isAttention;
        set
        {
            if (!value || _isMoving) return;
            _isAttention = value;
            animator.SetBool("IsAttention", value);
            StartCoroutine (
                WaitAndDo(.5f, ()=>{
                    Debug.Log("IsAttention");
                    _isAttention = false;
                    animator.SetBool("IsAttention", _isAttention);
                })
            );
        }
    }

    public bool CanMove
    {
        get => !IsUsing && !IsAttention;
    }

    private bool _isMoving = false;
    
    
    
    IEnumerator WaitAndDo (float time, Action action) {
        yield return new WaitForSeconds (time);
        action();
    }


    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && CanMove)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            _isJumpung = true;
            StartCoroutine (
                WaitAndDo(.3f, ()=>{
                    if (_isJumpung)
                    {
                        _isJumpung = !_isJumpung;
                        animator.SetBool("IsJumping", false);
                    }
                })
            );
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
        IsUsing = Input.GetButtonDown("Use");
        IsAttention = Input.GetButtonDown("Attention");

    }

    public void OnLanding()
    {
//        Debug.Log("OnLanding");
//        if (CanMove)
//        {
//        Debug.Log(CanMove);
//        animator.SetBool("IsJumping", false); 
            
//            StartCoroutine (
//                WaitAndDo(.5f, ()=>{
//                    Debug.Log("IsJumping");
//                    animator.SetBool("IsJumping", false);
//                })
//            );
//        }
    }

    public void OnFall(bool isFalling)
    {
        if (!_itWasFalling)
        {
            _itWasFalling = !_itWasFalling;
        }
        else
        {
            _itWasFalling = !isFalling;
            animator.SetBool("IsFalling", isFalling);
        }
    }

    public void OnCrouching (bool isCrouching)
    {
        if (CanMove)
        {
            animator.SetBool("IsCrouching", isCrouching);
        }
    }
    
    public void OnMoving (bool isMoving)
    {
        _isMoving = isMoving;
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        controller.CanMove = CanMove;
        jump = false;
    }
}