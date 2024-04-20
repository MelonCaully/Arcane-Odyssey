using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed = 10;
    private CameraZoom ZoomCamera;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (ZoomCamera.orthographic)
        {
            ZoomCamera.orthographicZoom -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            ZoomCameera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}
