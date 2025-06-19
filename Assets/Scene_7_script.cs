using UnityEngine;
using System.Collections;

public class FollowPlayerGaze : MonoBehaviour
{
    public Transform playerHead; // Assign the player's head/camera transform in the Inspector
    public Transform[] rootObjectsToFollow; // Assign the root objects you want to follow the gaze

    // Call this method to start following for 10 seconds
    public void FollowForTenSeconds()
    {
        StartCoroutine(FollowCoroutine());
    }

    private IEnumerator FollowCoroutine()
    {
        float timer = 0f;
        while (timer < 10f)
        {
            if (playerHead != null && rootObjectsToFollow != null)
            {
                Vector3 gazeDirection = playerHead.forward;

                foreach (Transform rootObj in rootObjectsToFollow)
                {
                    if (rootObj != null)
                    {
                        Vector3 currentPosition = rootObj.position;
                        Vector3 currentScale = rootObj.localScale;

                        // Make the object look in the same direction as the player's gaze
                        rootObj.rotation = Quaternion.LookRotation(gazeDirection, Vector3.up);

                        rootObj.position = currentPosition;
                        rootObj.localScale = currentScale;
                    }
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
}