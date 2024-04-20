using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        // Switch to 640 x 480 full-screen at 60 hz
        Screen.SetResolution(640, 480, FullScreenMode.ExclusiveFullScreen, 60);
    }
}
