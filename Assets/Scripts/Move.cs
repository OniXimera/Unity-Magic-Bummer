using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Move : MonoBehaviour
{
    //fix 05.12.2021
    [Header("Move Parametr")]
    [SerializeField] private float _height;
    [Header("Menu")]
    [SerializeField] private GameObject _menuObject;

    private bool _isGrounded;
    private int _tipAttack;
    private int _jumpPoints;
    private float _speed;
    private float _jumpForce;
    private float _inputX;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _speed = GetComponent<Player>().Speed;
        _jumpForce = GetComponent<Player>().JumpForce;
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerInput = new PlayerInput();
        _playerInput.Player.Jump.performed += ctx => OnJump();
        _playerInput.Player.Start.performed += ctx => OnMenu();
        _playerInput.Player.Action_1.performed += ctx => OnAction_1();
        _playerInput.Player.Action_2.performed += ctx => OnAction_2();
        _playerInput.Player.Action_3.performed += ctx => OnAction_3();
        _playerInput.Player.Action_4.performed += ctx => OnAction_4();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        OnMove();
    }

    bool IsGrounded()
    {
        foreach (RaycastHit2D item in Physics2D.RaycastAll(transform.position, -Vector3.up, _height))
        {
            if (item.collider.tag == "Ground")
                return true;
        }

        return false;
    }

    public void Spell()//Animation Event
    {
        GetComponent<Witchcraft>().UseSpell(_tipAttack);
    }
    public void OnMove()
    {
        _inputX = _playerInput.Player.Move.ReadValue<Vector2>().x;


        if (_inputX > 0)
             _spriteRenderer.flipX = true;
        else if (_inputX < 0)
            _spriteRenderer.flipX = false;

        _rigidbody2D.velocity = new Vector2(_inputX * _speed, _rigidbody2D.velocity.y);

        _isGrounded = IsGrounded();

        if (_isGrounded)
        {
            if (_animator.GetBool("Jump"))
                _animator.SetBool("Jump", false);
            else
                if (Mathf.Abs(_rigidbody2D.velocity.x) != 0)
                    _animator.SetBool("Run", true);
                else if (_animator.GetBool("Run"))
                    _animator.SetBool("Run", false);
        }
        else if (!_isGrounded && !_animator.GetBool("Jump"))
        {
            if (_animator.GetBool("Run"))
                _animator.SetBool("Run", false);

            _animator.SetBool("Jump", true);
        }
    }

    public void OnJump()
    {
        if (_isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
    }
    public void OnAction_1()
    {
        _tipAttack = 0;
        _animator.SetTrigger("Attack");
    }

    public void OnAction_2()
    {
        _tipAttack = 1;
        _animator.SetTrigger("Attack");
    }

    public void OnAction_3()
    {
        _tipAttack = 2;
        _animator.SetTrigger("Attack");
    }

    public void OnAction_4()
    {
        _tipAttack = 3;
        _animator.SetTrigger("Attack");
    }
    public void OnMenu()
    {
        if(_menuObject.activeSelf)
            _menuObject.SetActive(false);
        else
            _menuObject.SetActive(true);
    }
}
