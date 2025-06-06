using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 _moveInput;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    CapsuleCollider2D _myBodyCollider2D;
    BoxCollider2D _boxFeetCollider2D;
    [SerializeField] float _gravityScale = 2f;
    [SerializeField] float _playerSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] float climpSpeed;
    [SerializeField] bool _isAlive = true;
    [SerializeField] Vector2 DeathKick = new Vector2(-10f, 5f);
    [SerializeField] Transform _bow;
    [SerializeField] GameObject _arrow;

    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        _boxFeetCollider2D = GetComponent<BoxCollider2D>();
        _boxFeetCollider2D.enabled = false;
        StartCoroutine(ExampleCoroutine());
        _animator = GetComponent<Animator>();
        _gravityScale = _rigidbody2D.gravityScale;
    }

    void Update()
    {
        if (!_isAlive) { return; }
        Run();
        FlipSprite();
        Climpladder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!_isAlive) { return; }

        if (value.isPressed)
        {
            Debug.Log("pressed");
            _animator.SetTrigger("IsAttacking");
            Instantiate(_arrow, _bow.position, transform.rotation);

        }
    }

    void OnMove(InputValue value)
    {
        if (!_isAlive) { return; }
        _moveInput = value.Get<Vector2>();
        Debug.Log(_moveInput);
    }



    void OnJump(InputValue value)
    {
        if (!_isAlive) { return; }
        if (!_boxFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground", "Climping")))
        {
            _animator.SetBool("IsJumping", false);

            _boxFeetCollider2D.enabled = true;
            Debug.Log("working");
            return;
        }
        //else if (!_myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Climping")))
        //{
        //    Debug.Log("climping");
        //}
        if (value.isPressed)
        {
            Debug.Log("Jumping");
            _boxFeetCollider2D.enabled = false;
            _rigidbody2D.velocity += new Vector2(0f, JumpSpeed);
            _animator.SetBool("IsJumping", true);
        }

    }


    private void Run()
    {
        Vector2 playerVelocity = new Vector2(_moveInput.x * _playerSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("IsRunning", playerHasHorizontalSpeed);

    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);

        }
    }

    private void Climpladder()
    {
        if (!_boxFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climping")))
        {

            _animator.SetBool("IsClimbing", false);
            _rigidbody2D.gravityScale = _gravityScale;
            return;
        }
        else
        {
            Vector2 climprVelocity = new Vector2(_rigidbody2D.velocity.x, _moveInput.y * climpSpeed);
            _rigidbody2D.velocity = climprVelocity;
            _rigidbody2D.gravityScale = 0;

            bool playerHasVerticalSpeed = Mathf.Abs(_rigidbody2D.velocity.y) > Mathf.Epsilon;
            _animator.SetBool("IsClimbing", playerHasVerticalSpeed);
        }

    }

    void Die()
    {
        if (_myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hzerd")))
        {
            _isAlive = false;
            _animator.SetBool("IsSliding", true);
            _rigidbody2D.velocity = DeathKick;
            StartCoroutine(DeathCoroutine());
            FindObjectOfType<GameSession>().PorcessPlayerDeath();

        }
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        _boxFeetCollider2D.enabled = true;



    }
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(4);
        _animator.SetBool("IsSliding", false);
        _isAlive = true;
    }
}
