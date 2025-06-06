using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth _thePlayer;
    [SerializeField] float _damage = 20f;
    void Start()
    {
        _thePlayer = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (_thePlayer == null) { return; }
        _thePlayer.GetPlayerHealth(_damage);
    }


}
