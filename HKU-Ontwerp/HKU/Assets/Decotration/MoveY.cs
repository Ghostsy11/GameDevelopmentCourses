using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : MonoBehaviour
{
    // Start is called before the first frame update
    public
    void Start()
    {
        transform.DOMoveY(5f, 5f)
    .SetLoops(-1, LoopType.Yoyo)
    .SetEase(Ease.OutSine);
    }


}
