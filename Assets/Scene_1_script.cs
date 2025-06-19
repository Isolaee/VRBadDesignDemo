using UnityEngine;

public class VRPlayerHighJump : MonoBehaviour
{
    public float jumpHeight = 50f;
    public float jumpSpeed = 20f;

    private Vector3 targetPosition;
    private bool isJumping = false;

    public void HighJump()
    {
        if (!isJumping)
            StartCoroutine(HighJumpCoroutine());
    }

    private System.Collections.IEnumerator HighJumpCoroutine()
    {
        isJumping = true;
        targetPosition = transform.position + Vector3.up * jumpHeight;

        // Move up smoothly using transform.position
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, jumpSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isJumping = false;
    }
}