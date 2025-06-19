using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class FOVChanger : MonoBehaviour
{
    public Camera targetCamera;

    // Call this to change FOV to 60 for 10 seconds, then revert
    public void ChangeFOVForTenSeconds()
    {
        Debug.Log("Starting FOV change to 60 for 10 seconds.");
        StartCoroutine(ChangeFOVCoroutine());
    }

    private IEnumerator ChangeFOVCoroutine()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        XRDevice.fovZoomFactor = 1.1f;

        yield return new WaitForSeconds(10f);

        XRDevice.fovZoomFactor = 1;

    }
}