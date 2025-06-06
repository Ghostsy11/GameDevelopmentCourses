using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float ZoomingIn = 20f;
    [SerializeField] float ZoomingOut = 40f;
    [SerializeField] bool zoomedInToggle;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 1f;

    private void OnDisable()
    {
        ZoomOut();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                Zoomin();

            }
            else
            {
                ZoomOut();
            }
        }
    }


    private void Zoomin()
    {
        zoomedInToggle = true;
        _camera.fieldOfView = ZoomingIn;
    }
    private void ZoomOut()
    {
        zoomedInToggle = false;
        _camera.fieldOfView = ZoomingOut;
    }
}
