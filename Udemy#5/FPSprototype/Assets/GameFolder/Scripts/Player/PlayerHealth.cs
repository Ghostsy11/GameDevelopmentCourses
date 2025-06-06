using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _playerHealth = 100f;

    void Start()
    {


    }
    public void GetPlayerHealth(float _PlayerHealth)
    {

        _playerHealth -= _PlayerHealth;
        if (_playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }

    }

}
