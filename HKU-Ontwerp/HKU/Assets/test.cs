using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.tag);

            Debug.Log(other.gameObject.tag);
            other.gameObject.transform.position = new Vector3(6f, 6f, 6f);
        }
    }
}
