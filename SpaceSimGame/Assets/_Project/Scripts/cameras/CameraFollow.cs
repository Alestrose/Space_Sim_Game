using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Position offset from the ship
    public Vector3 positionOffset = new Vector3(0, 5, -20);

    // Optional point to look at (like the front of the ship)
    public Transform lookTarget;

    void LateUpdate()
    {
        if (target == null) return;

        // Position camera relative to the ship
        transform.position = target.TransformPoint(positionOffset);

        // Look at chosen target
        if (lookTarget != null)
            transform.LookAt(lookTarget);
        else
            transform.LookAt(target);
    }
}