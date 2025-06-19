using UnityEngine;
using System.Collections;

public class ShowSpriteInFront : MonoBehaviour
{
    public Sprite spriteToShow; // Assign your sprite in the Inspector
    public float distance = 2f; // Distance in front of the camera
    public Vector2 size = new Vector2(1f, 1f); // Size of the sprite

    private GameObject spawnedSprite;

    // Call this method to show the sprite in front of your face for 10 seconds, following your gaze
    public void ShowSpriteForTenSeconds()
    {
        StartCoroutine(ShowSpriteCoroutine());
    }

    private IEnumerator ShowSpriteCoroutine()
    {
        if (spriteToShow == null)
        {
            Debug.LogError("No sprite assigned!");
            yield break;
        }

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No main camera found!");
            yield break;
        }

        spawnedSprite = new GameObject("FloatingSprite");
        SpriteRenderer sr = spawnedSprite.AddComponent<SpriteRenderer>();
        sr.sprite = spriteToShow;
        sr.sortingOrder = 100;
        spawnedSprite.transform.localScale = new Vector3(size.x, size.y, 1f);

        float timer = 0f;
        while (timer < 10f)
        {
            // Always position the sprite in front of the camera
            spawnedSprite.transform.position = cam.transform.position + cam.transform.forward * distance;
            spawnedSprite.transform.LookAt(cam.transform);
            spawnedSprite.transform.Rotate(0, 180, 0);

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(spawnedSprite);
    }
}