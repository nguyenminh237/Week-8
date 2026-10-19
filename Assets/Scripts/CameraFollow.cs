
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float followDistance = 16f;
    public float followHeight = 10f;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Vi dau may bay huong ve -Z,
        // phia sau may bay la +Z
        Vector3 desiredPosition =
            target.position
            + target.forward * followDistance
            + Vector3.up * followHeight;

        // Camera di chuyen muot
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Camera nhin ve phia truoc may bay
        Vector3 lookAtPosition =
            target.position - target.forward * 6f;

        transform.LookAt(lookAtPosition);
    }
}
