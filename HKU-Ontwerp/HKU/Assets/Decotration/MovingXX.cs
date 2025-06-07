using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingXX : MonoBehaviour
{
    public float SpeedUp_ = 2;
    public GameObject Plane;
    void Start()
    {
        Plane.transform.DOMoveX(5f, 15f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.OutSine);
    }
}

