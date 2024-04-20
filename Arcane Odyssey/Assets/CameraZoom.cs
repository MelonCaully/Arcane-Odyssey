using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float sensitivity = 10f;
    private CinemachineFramingTransposer framingTransposer;
    
    void Start()
    {
        // Get the CinemachineFramingTransposer component
        if (virtualCamera != null)
        {
            framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the virtualCamera and framingTransposer are assigned
        if (virtualCamera != null && framingTransposer != null)
        {
            // Adjust the camera distance using the mouse scroll wheel input
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            framingTransposer.m_CameraDistance -= scroll * sensitivity * Time.deltaTime;
            
            // Clamp the camera distance to a reasonable range
            framingTransposer.m_CameraDistance = Mathf.Clamp(framingTransposer.m_CameraDistance, 
                                                             framingTransposer.m_MinimumDistance, 
                                                             framingTransposer.m_MaximumDistance);
        }
    }
}