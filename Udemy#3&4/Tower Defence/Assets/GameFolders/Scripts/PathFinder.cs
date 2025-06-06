using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int _startCoordinates;
    public Vector2Int StartCoordinates { get { return _startCoordinates; } }
    [SerializeField] Vector2Int _destinationCoordinates;
    public Vector2Int DestinationCoordinates { get { return _destinationCoordinates; } }

    private Node _startNode;
    private Node _DestinationNode;
    Node currentSearchNode;

    Queue<Node> _frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> _reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down, };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
            _startNode = gridManager.Grid[_startCoordinates];
            _DestinationNode = gridManager.Grid[_destinationCoordinates];

        }


    }
    void Start()
    {

        GetNewPath();

    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(_startCoordinates);
    }
    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNode();
        BreadthFirstSearch(coordinates);
        return BuildPath();
    }
    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nieghborsCoords = currentSearchNode._coordinates + direction;
            if (grid.ContainsKey(nieghborsCoords))
            {
                neighbors.Add(grid[nieghborsCoords]);

            }
        }

        foreach (Node nieghboor in neighbors)
        {
            if (!_reached.ContainsKey(nieghboor._coordinates) && nieghboor._iswalkable)
            {
                nieghboor._connectedTo = currentSearchNode;
                _reached.Add(nieghboor._coordinates, nieghboor);
                _frontier.Enqueue(nieghboor);
            }
        }

    }


    private void BreadthFirstSearch(Vector2Int XZCoordinates)
    {
        _startNode._iswalkable = true;
        _DestinationNode._iswalkable = true;
        _frontier.Clear();
        _reached.Clear();

        bool isRunning = true;
        _frontier.Enqueue(grid[XZCoordinates]);
        _reached.Add(XZCoordinates, grid[XZCoordinates]);
        while (_frontier.Count > 0 && isRunning)
        {
            currentSearchNode = _frontier.Dequeue();
            currentSearchNode._isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode._coordinates == _destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }


    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNoDe = _DestinationNode;



        while (currentNoDe._connectedTo != null)
        {
            currentNoDe = currentNoDe._connectedTo;
            path.Add(currentNoDe);
            currentNoDe._isPath = true;
        }

        path.Reverse();
        return path;

    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates]._iswalkable;
            grid[coordinates]._iswalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates]._iswalkable = previousState;

            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }

        }
        return false;

    }
    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.RequireReceiver);

    }

}
