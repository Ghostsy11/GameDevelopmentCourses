using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPicksUp : MonoBehaviour
{

    [SerializeField] int ammoAmount = 30;
    [SerializeField] AmmoType AmMoTYpe;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var incrase = FindObjectOfType<Ammo>();
            incrase.IncraseCurrentAmmo(AmMoTYpe, ammoAmount);
            Destroy(gameObject);
        }
    }
}
