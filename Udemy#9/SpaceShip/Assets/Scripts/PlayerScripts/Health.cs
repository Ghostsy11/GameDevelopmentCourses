using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem _particleEffect;
    [SerializeField] bool _applyCameraShake;
    CameraShake _cameraShake;
    AuidoPlayer _auidoPlayer;
    ScoreKeeper _scoreKeeper;
    LevelManager _levelManager;
    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _auidoPlayer = FindObjectOfType<AuidoPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.GetDamage();

            TakeDamae(damageDealer.GetDamage());
            PlayHitEffect();
            _auidoPlayer.PlayTakeDamageClip();
            ShakeCamera();
            damageDealer.Hit();

        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void ShakeCamera()
    {
        if (_cameraShake != null && _applyCameraShake)
        {
            _cameraShake.Play();
        }
    }

    private void TakeDamae(int damage)
    {

        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            _scoreKeeper.ModifyScore(score);
        }
        else
        {
            _levelManager.LoadGameOverScreen();
        }
        _auidoPlayer.PlayTakeDamageClipOnDestroy();
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (_particleEffect != null)
        {
            ParticleSystem instacne = Instantiate(_particleEffect, transform.position, Quaternion.identity);
            Destroy(instacne.gameObject, instacne.main.duration + instacne.main.startLifetime.constantMax);
        }
    }


}
