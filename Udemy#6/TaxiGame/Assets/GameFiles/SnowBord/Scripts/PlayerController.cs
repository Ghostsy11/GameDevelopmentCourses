using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb2d;
    [SerializeField] float _torque = 1f;
    [SerializeField] SurfaceEffector2D effector2D;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] bool _canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        effector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            RotatingPlayer();
            Boosters();
        }

    }

    public void DisableControl()
    {
        _canMove = false;
    }

    private void RotatingPlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(_torque);
            Debug.Log(_torque);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb2d.AddTorque(-_torque);
        }
        else return;
    }
    private void Boosters()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            effector2D.speed = boostSpeed;
        }
        else
        {
            effector2D.speed = baseSpeed;
        }
    }

}
