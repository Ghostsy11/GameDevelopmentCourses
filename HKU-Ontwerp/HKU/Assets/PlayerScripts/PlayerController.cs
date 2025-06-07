using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public bool disable = false;
    #region Variables: Movement

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    public float speed;

    [SerializeField] private MovemeantSprint _movemeantSprint;

    #endregion
    #region Variables: Rotation

    [SerializeField] private float rotationSpeed = 500f;
    private Camera _mainCamera;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    #endregion
    #region Variables: Jumping

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    public int maxNumberOfJumps = 2;

    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!disable)
        {
            ApplyRotation();
            ApplyGravity();
            ApplyMovement();
        }

    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void ApplyMovement()
    {
        var tagetSpeed = _movemeantSprint.isSpringing ? _movemeantSprint.speed * _movemeantSprint.speedMultiplier : speed;
        _movemeantSprint.currentSpEed = Mathf.MoveTowards(_movemeantSprint.currentSpEed, tagetSpeed, _movemeantSprint.acceleration * Time.deltaTime);
        _characterController.Move(_direction * _movemeantSprint.currentSpEed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _velocity = jumpPower;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movemeantSprint.isSpringing = context.started || context.performed;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);

        _numberOfJumps = 0;
    }

    private bool IsGrounded() => _characterController.isGrounded;
}
[Serializable]
public struct MovemeantSprint
{
    public float speed;
    public float speedMultiplier;
    public float acceleration;
    [HideInInspector] public bool isSpringing;
    [HideInInspector] public float currentSpEed;
}
