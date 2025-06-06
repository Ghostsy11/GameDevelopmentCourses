using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorerEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        Debug.Log("Another Hit!");
        var adding = GetComponent<Scorer>();
        adding.score++;
    }
}
