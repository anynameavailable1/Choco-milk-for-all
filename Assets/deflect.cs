using UnityEngine;
using System.Collections;

public class deflect : MonoBehaviour
{
    public Animator animator;              // assign Player's Animator
    public float parryWindowDuration = 0.08f; // fallback if you don't use events
    public float hitstopDuration = 0.06f;  // short freeze when parry succeeds
    public bool parryWindowActive { get; private set; } = false;
    bool canParry = true;

    void Update()
    {
        // Input: left mouse OR J
        if (canParry && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.F)))
        {
            animator.SetTrigger("ParryTrigger");
        }
    }

    // These are called via Animation Events (EnableParryWindow/DisableParryWindow)
    public void EnableParryWindow()
    {
        StopAllCoroutines();
        parryWindowActive = true;
        StartCoroutine(ParryWindowTimeout(parryWindowDuration)); // safety fallback
    }

    public void DisableParryWindow()
    {
        parryWindowActive = false;
        StopAllCoroutines();
    }

    IEnumerator ParryWindowTimeout(float t)
    {
        yield return new WaitForSeconds(t);
        parryWindowActive = false;
    }

    // Called when a parry successfully blocks an enemy attack
    public void OnParrySuccess(Vector3 pos)
    {
        StartCoroutine(DoHitstop());
        // optional: spawn VFX at pos, camera shake
        // CameraShake.Instance.Shake(0.08f, 0.2f);
        // Instantiate(parryVFX, pos, Quaternion.identity);
    }

    IEnumerator DoHitstop()
    {
        // basic hitstop: slow time to 0 for a short moment
        float original = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(hitstopDuration);
        Time.timeScale = original;
    }
}
