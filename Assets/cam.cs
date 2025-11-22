using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Player
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float zoom = 5f; // add this

    void LateUpdate()
    {
        if (target == null) return;

        // Smooth follow
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);

        // Apply zoom
        Camera.main.orthographicSize = zoom;
    }
}
