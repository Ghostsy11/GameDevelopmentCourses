using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{

    #region Actions

    public static event UnityAction<Vector3> CoinCollected;

    #endregion

    public static void OnCoinCollected(Vector3 position) => CoinCollected?.Invoke(position);

}
