using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower _towerPrefab;

    [SerializeField] bool IsPlaceable;
    public bool _Isplaceable
    {
        get
        {
            return IsPlaceable;
        }
    }
    public bool GetIsPlaceable()
    {
        return IsPlaceable;
    }

    GridManager GridManagergridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        GridManagergridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start()
    {
        if (GridManagergridManager != null)
        {
            coordinates = GridManagergridManager.GetCoordinatesFromPosition(transform.position);
            if (!IsPlaceable)
            {
                GridManagergridManager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown()
    {
        if (GridManagergridManager.GetNode(coordinates)._iswalkable && !pathFinder.WillBlockPath(coordinates))
        {

            bool isplaced = _towerPrefab.CreateTower(_towerPrefab, transform.position);
            if (isplaced)
            {

                GridManagergridManager.BlockNode(coordinates);
                pathFinder.NotifyReceivers();
            }


        }
    }

}
