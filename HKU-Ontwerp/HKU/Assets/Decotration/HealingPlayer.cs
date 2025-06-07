
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlayer : MonoBehaviour
{
    HealtH HealtH;
    public ParticleSystem healingparticales;

    private void Start()
    {
        healingparticales.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealingCube")
        {

            Debug.Log("Healing");
            healingparticales.Play();
            UIController.scoreCount += 1;
            HealtH = FindObjectOfType<HealtH>();
            HealtH.Healing(10);
            Destroy(other.gameObject, 1f);

        }
    }
}
