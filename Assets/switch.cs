using UnityEngine;

public class TransformInPlace : MonoBehaviour
{
    [Header("Assign Characters")]
    public GameObject blob;              // starting character
    public GameObject soulCatcher;     
    public GameObject player;  // playable soul catcher

    [Header("Camera")]
    public CameraFollow cameraFollow;    // your camera follow script

    [Header("Keybind")]
    public KeyCode swapKey = KeyCode.C;  // button to swap forms

    private GameObject activeCharacter;
    private GameObject inactiveCharacter;

    void Start()
    {
        // Blob is active at the start
        activeCharacter = blob;
        inactiveCharacter = soulCatcher;
    inactiveCharacter= player;
        // Make sure SoulCatcher is off at start
        soulCatcher.SetActive(false);
        player.SetActive(false);
        SetActiveCharacter(activeCharacter, inactiveCharacter);

        // Camera follows Blob
        cameraFollow.target = activeCharacter.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(swapKey))
        {
            SwapCharacters();
        }
    }

    void SwapCharacters()
    {
        // Move the inactive form to the active form's position
        inactiveCharacter.transform.position = activeCharacter.transform.position;

        // Swap references
        GameObject temp = activeCharacter;
        activeCharacter = inactiveCharacter;
        inactiveCharacter = temp;

        // Enable/disable proper components
        SetActiveCharacter(activeCharacter, inactiveCharacter);

        // Update camera target
        cameraFollow.target = activeCharacter.transform;
    }

    void SetActiveCharacter(GameObject active, GameObject inactive)
    {
        // Enable active character
        active.SetActive(true);

        // Disable inactive character
        inactive.SetActive(false);

        // Enable components on active
        var activeMove = active.GetComponent<PlayerMovement>();
        if (activeMove != null) activeMove.enabled = true;

        var activeAnim = active.GetComponent<Animator>();
        if (activeAnim != null) activeAnim.enabled = true;

        // Disable components on inactive
        var inactiveMove = inactive.GetComponent<PlayerMovement>();
        if (inactiveMove != null) inactiveMove.enabled = false;

        var inactiveAnim = inactive.GetComponent<Animator>();
        if (inactiveAnim != null) inactiveAnim.enabled = false;
    }
}
