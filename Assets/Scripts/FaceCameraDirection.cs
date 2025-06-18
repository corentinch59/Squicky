using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraDirection : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // get main camera and face it using its orientation rather than its position
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
        else
        {
            Debug.LogWarning("Main camera not found. Make sure there is a camera tagged as 'MainCamera'.");
        }
    }
}
