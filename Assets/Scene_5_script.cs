using UnityEngine;
using System.Collections;

public class PlayerTilt : MonoBehaviour
{
    public Transform xrRig; // Assign your XR Rig root transform in the Inspector

    // Call this method to tilt the XR Rig 15 degrees to the right for 10 seconds
    public void TiltRightForTenSeconds()
    {
        StartCoroutine(TiltCoroutine());
    }

    private IEnumerator TiltCoroutine()
    {
        if (xrRig == null)
        {
            Debug.LogError("XR Rig Transform not assigned!");
            yield break;
        }

        Quaternion originalRotation = xrRig.rotation;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, -5); // -15 on Z tilts right

        xrRig.rotation = targetRotation;
        Debug.Log("XR Rig tilted 15 degrees to the right.");

        yield return new WaitForSeconds(10f);

        xrRig.rotation = originalRotation;
        Debug.Log("XR Rig rotation reset.");
    }
}