using UnityEngine;
using UnityEngine.Events;

public class CollisionBeep : MonoBehaviour
{
    public GameObject collisionPartner; // Assign in Inspector
    public AudioClip beepSound;         // Assign in Inspector
    private AudioSource audioSource;
    public UnityEvent onClick; // Action TODO

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on " + gameObject.name + ". Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Only beep if the collision is with the specified partner
        if (collisionPartner != null && collision.gameObject == collisionPartner)
        {
            PlayBeep();
        }
    }

    void PlayBeep()
    {
        if (beepSound != null)
        {
            audioSource.PlayOneShot(beepSound);
            onClick.Invoke();
        }
        else
            Debug.LogWarning("No beepSound assigned on " + gameObject.name);
    }

}