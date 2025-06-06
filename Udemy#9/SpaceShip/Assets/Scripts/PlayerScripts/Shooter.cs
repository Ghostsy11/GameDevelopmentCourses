
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject _projextilePrefab;
    [SerializeField] float _projectileSpeed = 10f;
    [SerializeField] float _projectileLifeTime = 5f;
    [SerializeField] float _basefiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float spwanTimeVariance = 0f;
    [SerializeField] float minimumSpwanTime = 0.1f;

    [SerializeField] public bool _isFiring;
    Coroutine _firingCoroutine;
    AuidoPlayer _audioPlayer;
    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AuidoPlayer>();
    }

    void Start()
    {
        Debug.Log(useAI);
        if (useAI)
        {
            _isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (_isFiring && _firingCoroutine == null)
        {

            _firingCoroutine = StartCoroutine(FireCountiously());
        }
        else if (!_isFiring && _firingCoroutine != null)
        {

            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FireCountiously()
    {
        while (true)
        {

            GameObject instance = Instantiate(_projextilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * _projectileSpeed;
            }
            Destroy(instance, _projectileLifeTime);
            _audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(GetRandomTimeBetweenEveryProjectile());
        }

    }

    private float GetRandomTimeBetweenEveryProjectile()
    {
        float spwanTimeBetweenProjectile = Random.Range(_basefiringRate - spwanTimeVariance, _basefiringRate + spwanTimeVariance);
        return Mathf.Clamp(spwanTimeBetweenProjectile, minimumSpwanTime, float.MaxValue);
    }

}
