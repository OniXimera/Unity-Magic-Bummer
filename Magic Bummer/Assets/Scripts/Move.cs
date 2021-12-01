using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Move : MonoBehaviour
{
    //fix 30.11.2021
    [Header("Move Parametr")]
    [SerializeField] private float _height;
    [Header("Menu")]
    [SerializeField] private GameObject _menuObject;

    private bool _isGrounded;
    private int _tipAttack;
    private float _speed;
    private float _jumpForce;
    private float _inputX;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;

    private void Awake()
    {
        this._speed = GetComponent<Player>().Speed;
        this._jumpForce = GetComponent<Player>().JumpForce;
        this._animator = GetComponent<Animator>();
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._spriteRenderer = GetComponent<SpriteRenderer>();

        this._playerInput = new PlayerInput();
        this._playerInput.Player.Jump.performed += ctx => OnJump();
        this._playerInput.Player.Start.performed += ctx => OnMenu();
        this._playerInput.Player.Action_1.performed += ctx => OnAction_1();
        this._playerInput.Player.Action_2.performed += ctx => OnAction_2();
        this._playerInput.Player.Action_3.performed += ctx => OnAction_3();
        this._playerInput.Player.Action_4.performed += ctx => OnAction_4();
    }
    private void OnEnable()
    {
        this._playerInput.Enable();

    }

    private void OnDisable()
    {
        this._playerInput.Disable();
    }

    private void Update()
    {
        OnMove();
    }

    bool IsGrounded()
    {
        foreach (RaycastHit2D item in Physics2D.RaycastAll(transform.position, -Vector3.up, this._height))
        {
            if (item.collider.tag == "Ground")
                return true;
        }
        return false;
    }

    public void Spell()//Animation Event
    {
        GetComponent<Witchcraft>().UseSpell(this._tipAttack);
    }
    public void OnMove()
    {
        this._inputX = this._playerInput.Player.Move.ReadValue<Vector2>().x;


        if (this._inputX > 0)
             this._spriteRenderer.flipX = true;
        else if (this._inputX < 0)
            this._spriteRenderer.flipX = false;

        this._rigidbody2D.velocity = new Vector2(this._inputX * this._speed, this._rigidbody2D.velocity.y);

        this._isGrounded = IsGrounded();
        if (this._isGrounded)
        {
            if (this._animator.GetBool("Jump"))
                this._animator.SetBool("Jump", false);
            else
                if (Mathf.Abs(this._rigidbody2D.velocity.x) != 0)
                    this._animator.SetBool("Run", true);
                else if (this._animator.GetBool("Run"))
                    this._animator.SetBool("Run", false);
        }
        else if (!this._isGrounded && !this._animator.GetBool("Jump"))
        {
            if (this._animator.GetBool("Run"))
                this._animator.SetBool("Run", false);
            this._animator.SetBool("Jump", true);
        }
    }

    public void OnJump()
    {
        if (this._isGrounded)
        {
            this._rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, this._jumpForce);
        }
    }
    public void OnAction_1()
    {
        this._tipAttack = 0;
        this._animator.SetTrigger("Attack");
    }

    public void OnAction_2()
    {
        this._tipAttack = 1;
        this._animator.SetTrigger("Attack");
    }

    public void OnAction_3()
    {
        this._tipAttack = 2;
        this._animator.SetTrigger("Attack");
    }

    public void OnAction_4()
    {
        this._tipAttack = 3;
        this._animator.SetTrigger("Attack");
    }
    public void OnMenu()
    {
        if(this._menuObject.activeSelf)
            this._menuObject.SetActive(false);
        else
            this._menuObject.SetActive(true);
    }
}
