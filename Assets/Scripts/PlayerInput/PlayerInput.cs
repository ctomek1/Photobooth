using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1;
    [SerializeField]
    private float zoomSensitivity;
    
    private float XRotation;
    private float YRotation;
    private float minFov = 15f;
    private float maxFov = 90f;

    private int screenShotCounter = 1;

    private void OnMouseDrag()
    {
        XRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        YRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        if (Input.GetMouseButton(0) == true)
        {
            transform.Rotate(Vector3.down, XRotation, Space.World);
            transform.Rotate(Vector3.right, YRotation, Space.World);
        }
    }

    public void HandleZooming()
    {
        var fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    public void TakeScreenShot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Output/" + screenShotCounter.ToString() + ".png");
        screenShotCounter++;
    }
}
