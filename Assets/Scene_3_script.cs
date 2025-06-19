using UnityEngine;
using System.Collections;

public class RaycastCrosshair : MonoBehaviour
{
    public Camera rayCamera; // Assign the camera to cast from (or leave null for Camera.main)
    public float maxDistance = 100f;
    public LayerMask raycastLayers = ~0; // All layers by default
    public GameObject crosshairPrefab; // Assign a prefab with an image (e.g., a small quad or sprite)

    private GameObject crosshairInstance;
    private bool crosshairActive = false;

    void Start()
    {
        if (crosshairPrefab != null)
        {
            crosshairInstance = Instantiate(crosshairPrefab);
            crosshairInstance.SetActive(false);
        }
    }

    void Update()
    {
        if (!crosshairActive || crosshairInstance == null)
            return;

        Camera cam = rayCamera != null ? rayCamera : Camera.main;
        if (cam == null)
            return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, raycastLayers))
        {
            crosshairInstance.SetActive(true);
            crosshairInstance.transform.position = hit.point + hit.normal * 0.01f;
            crosshairInstance.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            crosshairInstance.SetActive(false);
        }
    }

    // Call this method to activate the crosshair for 10 seconds
    public void ActivateCrosshairForTenSeconds()
    {
        StartCoroutine(CrosshairCoroutine());
    }

    private IEnumerator CrosshairCoroutine()
    {
        crosshairActive = true;
        if (crosshairInstance != null)
            crosshairInstance.SetActive(true);

        yield return new WaitForSeconds(10f);

        crosshairActive = false;
        if (crosshairInstance != null)
            crosshairInstance.SetActive(false);
    }
}