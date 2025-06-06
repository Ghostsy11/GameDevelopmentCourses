using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] float _arrowSpeed = 20f;
    Rigidbody2D RG;
    PlayerMovement _player;
    float Xspeed;
    [SerializeField] float _timeToDestroyArrow;
    [SerializeField] float _timeToDestroyEnemy;
    // Start is called before the first frame update
    void Start()
    {
        RG = GetComponent<Rigidbody2D>();
        _player = FindAnyObjectByType<PlayerMovement>();
        Xspeed = _player.transform.localScale.x * _arrowSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hello" + Xspeed);
        RG.velocity = new Vector2(Xspeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject, _timeToDestroyEnemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, _timeToDestroyArrow);
    }

}
