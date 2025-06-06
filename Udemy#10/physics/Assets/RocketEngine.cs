using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{
    public float fuelMass; // [Kg]
    public float maxThrust; //kN [kg m s^2]
    [Range(0, 1)]
    public float thrustPercent; // [none]

    [SerializeField] Vector3 thrustUnitVector; // [none]
    PhysicsEngine _physicsengine;

    private float currentThrst;
    // SetUpLineRederer is called before the first frame update
    void Start()
    {
        _physicsengine = GetComponent<PhysicsEngine>();
        _physicsengine.mass += fuelMass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            _physicsengine.mass -= FuelThisUpdate();
            _physicsengine.AddForce(thrustUnitVector);
            ExtertForce();
        }
        else
        {
            Debug.LogWarning("Out of fuel");
        }
    }

    private float FuelThisUpdate()
    {
        float exhaustMassFlow; //[Kg]
        float effectiveExhausVelcoity; //[kN]

        effectiveExhausVelcoity = 4462f; // [m s^-1]
        exhaustMassFlow = currentThrst / effectiveExhausVelcoity;

        return exhaustMassFlow * Time.deltaTime; //[Kg]
    }

    private void ExtertForce()
    {
        currentThrst = thrustPercent * maxThrust * 1000f;
        Vector3 thrustVector = thrustUnitVector.normalized * currentThrst;
        _physicsengine.AddForce(thrustVector);

    }


}
