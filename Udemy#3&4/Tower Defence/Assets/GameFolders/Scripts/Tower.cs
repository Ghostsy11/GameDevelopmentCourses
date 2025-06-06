using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int Cost = 75;
    [SerializeField] float BuildDelay = 1f;

    private void Start()
    {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        TheBank theBank = FindObjectOfType<TheBank>();
        if (theBank == null)
        {
            return false;
        }
        if (theBank.CurrentBalance >= Cost)
        {

            Instantiate(tower.gameObject, position, Quaternion.identity);
            theBank.Withdraw(Cost);
            return true;
        }
        return false;
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(BuildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }
}
