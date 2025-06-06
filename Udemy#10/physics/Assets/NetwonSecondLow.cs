using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetwonSecondLow : MonoBehaviour
{
    [Header("NewTon First Low's: “When viewed in an inertial reference frame,\n an object either remains at rest or continues to move at a constant velocity," +
       "\n unless acted upon by an external force.” ")]
    [Header("NewTon Second Low's: (vector3)Force f = (float) m * (vector3) accelration a and a = f / m .” ")]
    [Header("NewTon Third Low's:  forceAonB = - forceBonA ")]

    [Header("Vector's, object loaction and Velocity")]
    [Tooltip("To use how fast the object goes in which direaction")]
    public Vector3 _VelocitySnelheid;
    [Tooltip("_EndforceSpeed is the avrage velocity")]
    public Vector3 _EndforceSpeed;
    [Tooltip("Add unbalance speed froces to applied on the object and see how Neton first low work")]
    public List<Vector3> _forceSpeedLists = new List<Vector3>();
    [Header("Mass is how much does an object weight")]
    [Tooltip("To find out about the accelrationSpeed a = f / m see in exapmle UpdateVelocityForce")]
    public float mass;

    [Header("Time Testing Between Update and FixedUpdate")]
    [Tooltip("Time Class and function deltaTime return the current time vaule. For exmple look at currentTimeVauleNowInUpdate")]
    [SerializeField] float currentTimeVauleNowInUpdate;
    [SerializeField] float currentTimeVauleInFixedUpdate;
    private void FixedUpdate()
    {
        Debug.Log(TimeTesting(currentTimeVauleInFixedUpdate));

        AddAcuallyForce();
        UpdateVelocityMass();
        MoveObject();
    }
    private void Update()
    {
        Debug.Log(TimeTesting(currentTimeVauleNowInUpdate));

    }
    private void AddAcuallyForce()
    {
        foreach (var f in _forceSpeedLists)
        {
            _EndforceSpeed = _EndforceSpeed + f;
        }
    }
    private void MoveObject()
    {
        transform.position += _VelocitySnelheid;
    }

    private void UpdateVelocityMass()
    {
        Vector3 accelrationVector = _EndforceSpeed / mass;
        _VelocitySnelheid += accelrationVector * Time.deltaTime;
    }
    private float TimeTesting(float currentTime)
    {
        return currentTime += Time.deltaTime;

    }
}
