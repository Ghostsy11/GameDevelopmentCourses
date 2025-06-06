using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] float xAngel = 0f;
    [SerializeField] float yAngel = 0f;
    [SerializeField] float zAngel = 0f;

    void Update()
    {
        transform.Rotate(xAngel, yAngel, zAngel);
    }
}
