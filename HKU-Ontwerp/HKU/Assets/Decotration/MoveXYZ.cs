using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXYZ : MonoBehaviour
{
    public GameObject _object;
    public Vector3 _MoveBetween;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 ThreeAXIS = _MoveBetween;
        transform.DOMove(ThreeAXIS, 20f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.OutSine);
    }

}
