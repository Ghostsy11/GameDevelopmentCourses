using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Node> _path = new List<Node>();
    [SerializeField][Range(0f, 10f)] float _speed = 1f;
    Enemy enemy;
    GridManager _gridManaGer;
    PathFinder __PathFinder;
    //[SerializeField] float _waitForSeconds;
    private void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);



    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        _gridManaGer = FindObjectOfType<GridManager>();
        __PathFinder = FindObjectOfType<PathFinder>();
    }
    private void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = __PathFinder.StartCoordinates;
        }
        else
        {
            coordinates = _gridManaGer.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        _path.Clear();
        _path = __PathFinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = _gridManaGer.GetPositionFromCoordinates(__PathFinder.StartCoordinates);
    }

    private void FinishPath()
    {
        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        for (int i = 1; i < _path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = _gridManaGer.GetPositionFromCoordinates(_path[i]._coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            //transform.position = waypoint.transform.position;
            //Debug.Log(waypoint.name);
            //yield return new WaitForSeconds(_waitForSeconds);
        }
        FinishPath();
    }

}
