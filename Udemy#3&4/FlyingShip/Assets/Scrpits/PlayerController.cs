using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General SetUp Settings For ShipController")]
    [Tooltip("How Fast The Ship Moves")][SerializeField] float _Speed = 30f;
    [SerializeField] float _Xrange = 10f;
    [SerializeField] float _Yrange = 7f;
    [Header("Array of Bullets")]
    [Tooltip("Add all bullets into this array")][SerializeField] GameObject[] Bullets;

    [Header("Screen position based on tuning")]
    [SerializeField] float _PositionPitchFactor = -2f;
    [SerializeField] float _ControlPitchFactor = -15f;
    [Header("Player Input based on tuning")]
    [SerializeField] float _ControlPitchFactorYaw = 2f;
    [SerializeField] float _ControlRollFactor = -20f;
    float HorizontalMovement;
    float VerticalMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlyMethod();
        RotationHandler();
        ProcessFiring();

    }

    private void PlayerFlyMethod()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        float OldposH = HorizontalMovement * _Speed * Time.deltaTime;
        float NewPosH = transform.localPosition.x + OldposH;
        float Sideslimits = Mathf.Clamp(NewPosH, -_Xrange, _Xrange);
        float OldposY = VerticalMovement * _Speed * Time.deltaTime;
        float NewPosY = transform.localPosition.y + OldposY;
        float HighLimits = Mathf.Clamp(NewPosY, -_Yrange, _Yrange);
        transform.localPosition = new Vector3(Sideslimits, HighLimits, transform.localPosition.z);
    }

    private void RotationHandler()
    {
        float pitch = transform.localPosition.y * _PositionPitchFactor + VerticalMovement * _ControlPitchFactor;
        float yaw = transform.localPosition.x * _ControlPitchFactorYaw;
        float roll = HorizontalMovement * _ControlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetBulletsActive(true);
        }
        else
        {
            SetBulletsActive(false);

        }

    }

    private void SetBulletsActive(bool isActive)
    {

        foreach (GameObject bullet in Bullets)
        {
            bullet.SetActive(true);
            var emissionModule = bullet.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }

    }

}
