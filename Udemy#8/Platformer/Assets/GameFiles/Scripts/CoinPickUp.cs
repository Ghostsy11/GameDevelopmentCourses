using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    [SerializeField] AudioClip _audioClip;
    [SerializeField] int _amountofCoinsToPickUp = 1;
    [SerializeField] bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(_amountofCoinsToPickUp);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
