using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timerOfDropping = 3f;
    MeshRenderer renderer;
    Rigidbody Rigidbodyrb;
    private void Start()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Rigidbody>().useGravity = false;
        renderer = GetComponent<MeshRenderer>();
        Rigidbodyrb = GetComponent<Rigidbody>();
        renderer.enabled = false;
        Rigidbodyrb.useGravity = false;
    }
    void Update()
    {
        if (Time.time > timerOfDropping)
        {
            //GetComponent<MeshRenderer>().enabled = true;
            //GetComponent<Rigidbody>().useGravity = true;
            renderer.enabled = true;
            Rigidbodyrb.useGravity = true;
        }


    }
}
