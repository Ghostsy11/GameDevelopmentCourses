using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    [SerializeField] float _timeTillItDestroied;

    void Start()
    {
        Destroy(gameObject, _timeTillItDestroied);
    }

}
