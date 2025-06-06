using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5;
    Vector2 _rawInput;
    [SerializeField] float _paddingleft;
    [SerializeField] float _paddingRight;
    [SerializeField] float _paddingtop;
    [SerializeField] float _paddingbottom;
    [SerializeField] Vector2 _minBounds;
    [SerializeField] Vector2 _maxBounds;

    Shooter _Shooter;

    private void Awake()
    {
        _Shooter = GetComponent<Shooter>();
    }
    private void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }
    void InitBounds()
    {
        Camera mainCamer = Camera.main;
        _minBounds = mainCamer.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamer.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void Move()
    {
        Vector2 delta = _rawInput * _movementSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + _paddingleft, _maxBounds.x - _paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + _paddingbottom, _maxBounds.y - _paddingtop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (_Shooter != null)
        {
            _Shooter._isFiring = value.isPressed;
        }

    }
}
