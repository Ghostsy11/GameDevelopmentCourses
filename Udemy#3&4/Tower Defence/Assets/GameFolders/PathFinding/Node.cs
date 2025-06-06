using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int _coordinates;
    public bool _iswalkable;
    public bool _isExplored;
    public bool _isPath;
    public Node _connectedTo;

    public Node(Vector2Int _coordinates, bool _iswalkable)
    {
        this._coordinates = _coordinates;
        this._iswalkable = _iswalkable;
    }
}
