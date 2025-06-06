using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float _steerSpeed = 1f;
    [SerializeField] float _moveSpeed = 20f;
    [SerializeField] float _slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    public void MoverSpeed()
    {
        _moveSpeed = boostSpeed;

    }

    public void SlowerMove()
    {
        _moveSpeed = _slowSpeed;
    }
    void Update()
    {
        CarMover();
    }

    private void CarMover()
    {
        var DeltaTime = Time.deltaTime;
        var _horizontal = Input.GetAxis("Horizontal") * _steerSpeed * DeltaTime;
        var _vertical = Input.GetAxis("Vertical") * _moveSpeed * DeltaTime;

        transform.Rotate(0, 0, -_horizontal);
        transform.Translate(new Vector3(0, _vertical, 0));
    }
}
