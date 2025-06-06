using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject _spriteRenderer;
    [SerializeField] bool _hasPackage = false;
    [SerializeField] float _delayTime = 1f;
    [SerializeField] Color32 _hasPackageColor = new Color32();
    [SerializeField] Color32 _noPackageColor = new Color32();
    Driver _driver;

    private void Start()
    {
        _driver = GetComponent<Driver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box" && !_hasPackage)
        {
            _hasPackage = true;
            _spriteRenderer.GetComponent<SpriteRenderer>().color = Color.green;
            Destroy(collision.gameObject, _delayTime);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Custormer" && _hasPackage)
        {
            Debug.Log("Deliveried");
            _hasPackage = false;
            _spriteRenderer.GetComponent<SpriteRenderer>().color = Color.yellow;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {
            Debug.Log("boost");
            _driver.MoverSpeed();
        }
        else if (collision.gameObject.tag != "Box")
        {
            Debug.Log("slow");
            _driver.SlowerMove();
        }
        else if (collision.gameObject.tag != "Custormer")
        {
            Debug.Log("slow");
            _driver.SlowerMove();

        }

        else return;

    }

}
