using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject _toFollowTheCar;
    private void LateUpdate()
    {
        transform.position = _toFollowTheCar.transform.position + new Vector3(0, 0, -10);
    }
}
