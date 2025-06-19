using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotoUIFlyIn : MonoBehaviour
{
    public Canvas worldSpaceCanvasPrefab; // Assign a World Space Canvas prefab in Inspector
    public Sprite photoSprite;            // Assign the photo sprite in Inspector
    public float startDistance = 20f;     // How far away to spawn the UI
    public float moveSpeed = 10f;         // Units per second

    private GameObject spawnedUI;

    // Call this method to create and move the UI photo
    public void ShowPhotoUI()
    {
        StartCoroutine(SpawnAndMovePhotoUI());
    }

    private IEnumerator SpawnAndMovePhotoUI()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No main camera found!");
            yield break;
        }

        Vector3 startPos = cam.transform.position + cam.transform.forward * startDistance;
        Vector3 endPos = cam.transform.position + cam.transform.forward * 8f;

        Canvas canvasInstance = Instantiate(worldSpaceCanvasPrefab, startPos, Quaternion.identity);
        canvasInstance.renderMode = RenderMode.WorldSpace;
        canvasInstance.transform.LookAt(cam.transform);
        canvasInstance.transform.Rotate(0, 180, 0);

        GameObject imageGO = new GameObject("PhotoImage", typeof(RectTransform), typeof(Image));
        imageGO.transform.SetParent(canvasInstance.transform, false);
        Image img = imageGO.GetComponent<Image>();
        img.sprite = photoSprite;
        img.preserveAspect = true;
        img.rectTransform.sizeDelta = new Vector2(400, 400);

        spawnedUI = canvasInstance.gameObject;

        while (Vector3.Distance(canvasInstance.transform.position, endPos) > 0.01f)
        {
            float step = moveSpeed * Time.deltaTime;
            canvasInstance.transform.position = Vector3.MoveTowards(canvasInstance.transform.position, endPos, step);
            canvasInstance.transform.LookAt(cam.transform);
            canvasInstance.transform.Rotate(0, 180, 0);
            yield return null;
        }

        canvasInstance.transform.position = endPos;
        canvasInstance.transform.LookAt(cam.transform);
        canvasInstance.transform.Rotate(0, 180, 0);

        // Wait 10 seconds, then destroy the UI
        yield return new WaitForSeconds(10f);
        Destroy(canvasInstance.gameObject);
    }
}