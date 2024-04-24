using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 10f;

    private void Update()
    {
        // Get the scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate new zoom level
        float zoomLevel = virtualCamera.m_Lens.OrthographicSize - scrollInput * zoomSpeed;

        // Clamp the zoom level between minZoom and maxZoom
        zoomLevel = Mathf.Clamp(zoomLevel, minZoom, maxZoom);

        // Set the new zoom level
        virtualCamera.m_Lens.OrthographicSize = zoomLevel;
    }
}