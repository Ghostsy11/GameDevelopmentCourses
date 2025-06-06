using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int _gridSize;
    [Tooltip("world grid size should match the unity editor snap settenigs.")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int co)
    {
        if (grid.ContainsKey(co))
        {

            return grid[co];
        }

        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates]._iswalkable = false;
        }
    }

    public void ResetNode()
    {
        foreach (KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value._connectedTo = null;
            entry.Value._isExplored = false;
            entry.Value._isPath = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int Coordinates = new Vector2Int();
        Coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        Coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return Coordinates;

    }

    public Vector3 GetPositionFromCoordinates(Vector2Int __Coordinates)
    {
        Vector3 position = new Vector3();
        position.x = __Coordinates.x * unityGridSize;
        position.z = __Coordinates.x * unityGridSize;
        return position;
    }


    private void CreateGrid()
    {
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector2Int co = new Vector2Int(x, y);
                grid.Add(co, new Node(co, true));
            }
        }
    }
}
