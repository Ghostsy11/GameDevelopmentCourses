using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    Vector3 StartingPoint;
    [SerializeField] Vector3 movemenatVector;
    [SerializeField][Range(0, 1)] float movementfactor;
    [SerializeField] float period = 2;

    private void Start()
    {
        StartingPoint = transform.position;
        Debug.Log(StartingPoint);
    }
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementfactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movemenatVector * movementfactor;
        transform.position = StartingPoint + offset;
    }
}
