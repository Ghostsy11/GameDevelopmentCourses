using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReSpAwan : MonoBehaviour
{
    PlayerController Speler;
    public Vector3 TeleportTO;
    private void Start()
    {
        Speler = GetComponent<PlayerController>();

    }
    IEnumerator delayteleport()
    {
        Debug.Log("pressing l");
        Speler.disable = true;
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position = TeleportTO;
        yield return new WaitForSeconds(0.01f);
        Speler.disable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MovePoint")
        {
            Debug.Log(other.gameObject.tag);
            StartCoroutine("delayteleport");
        }
    }
}
