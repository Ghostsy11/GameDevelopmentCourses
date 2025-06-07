using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(10f, 20f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.OutSine);
    }

}
