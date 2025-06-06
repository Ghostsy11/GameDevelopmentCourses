using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color _difaultColor = Color.white;
    [SerializeField] Color _blokedColor = Color.red;
    [SerializeField] Color _exloredColor = Color.yellow;
    [SerializeField] Color _pathColor = Color.gray;
    TextMeshPro _lable;
    Vector2Int _coordinates = new Vector2Int();
    GridManager _gridManager;

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _lable = GetComponent<TextMeshPro>();
        _lable.enabled = false;
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            //_lable.enabled = true; use when making a new scene
        }
        //if (Application.isPlaying)
        //{
        //    DisplayCoordinates();
        //    UpdateObjectName();
        //}
        ToggleLables();
        SetLableColor();
    }


    private void ToggleLables()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            _lable.enabled = !_lable.IsActive();
        }
    }
    private void SetLableColor()
    {

        if (_gridManager == null) { return; }
        Node node = _gridManager.GetNode(_coordinates);
        if (node == null) { return; }

        else if (!node._iswalkable)
        {
            _lable.color = _blokedColor;

        }
        else if (node._isPath)
        {
            _lable.color = _pathColor;
        }
        else if (node._isExplored)
        {
            _lable.color = _exloredColor;
        }
        else
        {
            _lable.color = _difaultColor;
        }
    }

    private void DisplayCoordinates()
    {
        if (_gridManager == null) { return; }
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x / _gridManager.UnityGridSize);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z / _gridManager.UnityGridSize);
        _lable.text = _coordinates + " " + _coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }

}
