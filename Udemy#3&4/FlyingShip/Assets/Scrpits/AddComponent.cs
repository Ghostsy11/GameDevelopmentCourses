using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent : MonoBehaviour
{
    void Start()
    {
        AddingCompnent();
    }
    private void AddingCompnent()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
