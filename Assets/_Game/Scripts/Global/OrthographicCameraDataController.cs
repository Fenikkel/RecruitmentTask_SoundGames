
using UnityEngine;

public static class OrthographicCameraDataController
{
    public static float GetScreenWidthInUnits() 
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError($"Tag your main camera if you want to use <b>{typeof(OrthographicCameraDataController)}</b>");
            return -1;
        }

        if (!mainCamera.orthographic) 
        {
            Debug.LogError($"The main camera needs to be <b>orthographic</b> for this function");
            return -2;
        }

        return mainCamera.orthographicSize * mainCamera.aspect * 2; 
    }

    public static float GetScreenHeightInUnits()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError($"Tag your main camera if you want to use <b>{typeof(OrthographicCameraDataController)}</b>");
            return -1;
        }

        if (!mainCamera.orthographic)
        {
            Debug.LogError($"The main camera needs to be <b>orthographic</b> for this function");
            return -2;
        }

        return mainCamera.orthographicSize * 2;
    }
}
