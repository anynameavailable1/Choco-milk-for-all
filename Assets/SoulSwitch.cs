using UnityEngine;

public class SoulAbsorb : MonoBehaviour
{
    [Header("References")]
    public GameObject blob;                 // Your starting player
    public GameObject soulCatcher;          // Playable SoulCatcher
    public TransformInPlace swapScript;     // Your TransformInPlace script
    public KeyCode absorbKey = KeyCode.E;   // Key to absorb

    private bool inside = false;
    private bool absorbed = false;

    void Start()
    {
        // Make sure SoulCatcherPlayable is inactive at start
        soulCatcher.SetActive(false);

        // Disable swap script until absorption
        if (swapScript != null)
            swapScript.enabled = false;
            Camera.main.GetComponent<CameraFollow>().target = blob.transform;
    }

    void Update()
    {
        if (inside && !absorbed && Input.GetKeyDown(absorbKey))
        {
            Absorb();
        }
    }

    void Absorb()
    {
        absorbed = true;

        // Move SoulCatcherPlayable to Blob's current position
        soulCatcher.transform.position = blob.transform.position;

        // Enable swap script now, if you want swapping after absorption
        if (swapScript != null)
            swapScript.enabled = true;

        // Disable or destroy Blob
        blob.SetActive(false);   // safer than Destroy in case you want to reference it later

        // Activate SoulCatcherPlayable
        soulCatcher.SetActive(true);

        // Update camera to follow SoulCatcher
        Camera.main.GetComponent<CameraFollow>().target = soulCatcher.transform;

        // Remove SoulCatcherBody from the scene (this trigger object)
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == blob)
            inside = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == blob)
            inside = false;
    }
}
