using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    [SerializeField] float SpeedMovement = 0;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMent();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move with WASD");
        Debug.Log("Don't hit the walls!");
    }

    void MoveMent()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * SpeedMovement;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * SpeedMovement;
        transform.Translate(xValue, 0, zValue);
    }

}
