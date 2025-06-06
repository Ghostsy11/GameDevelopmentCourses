using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PhysicsEngine))]
public class PhysicsEngine : MonoBehaviour
{

    private const float bigG = 6.673e-11f; //  [kg m3 s^-2 kg-1]

    public float mass; // [kg]
    public Vector3 _VelocitySnelheid; // [m s^-1]
    public Vector3 _EndforceSpeed; // N [Kg m s^2]
    private List<Vector3> _forceSpeedLists = new List<Vector3>();
    private PhysicsEngine[] physicsEngineArray;
    private void Start()
    {
        SetLine();
        physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Drwa();
        CalculateGravuty();
        UpdateVelocityForce();

    }

    private void CalculateGravuty()
    {
        foreach (PhysicsEngine physicsEngineA in physicsEngineArray)
        {
            foreach (PhysicsEngine physicsEngineB in physicsEngineArray)
            {
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {

                    Debug.Log("calculating gravitational force exereted on " + physicsEngineA.name + ": " + physicsEngineB.name);
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitude = bigG * physicsEngineA.mass * physicsEngineB.mass / rSquared;
                    Vector3 graviFeltVector = gravityMagnitude * offset.normalized;

                    physicsEngineA.AddForce(-graviFeltVector);
                }
            }
        }
    }

    private void UpdateVelocityForce()
    {
        _EndforceSpeed = Vector3.zero;
        foreach (var f in _forceSpeedLists)
        {
            _EndforceSpeed = _EndforceSpeed + f;
        }
        _forceSpeedLists = new List<Vector3>();

        Vector3 accelrationVector = _EndforceSpeed / mass;
        _VelocitySnelheid += accelrationVector * Time.deltaTime;
        transform.position += _VelocitySnelheid;
    }

    public bool showTrails = true;

    private LineRenderer lineRenderer;
    private int numberOfForces;

    void SetLine()
    {

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(Color.yellow, Color.yellow);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.useWorldSpace = false;
    }

    void Drwa()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = _forceSpeedLists.Count;
            lineRenderer.SetVertexCount(numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in _forceSpeedLists)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void AddForce(Vector3 forceVector)
    {
        _forceSpeedLists.Add(forceVector);
    }

}
