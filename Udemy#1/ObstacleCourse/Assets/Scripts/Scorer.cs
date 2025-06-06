using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int score = 0;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Hitt")
        {
            score++;
            Debug.Log("You have hit an object this many times:" + score);
        }
        else if (collision.gameObject.tag == "Hitt")
        {
            Debug.Log("You already hitted that object");
        }
    }
}
