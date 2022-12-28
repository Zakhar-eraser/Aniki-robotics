using UnityEngine;

public class VelocityProbe : MonoBehaviour
{
    private Vector3 lastPosition;
    public Vector3 moveDirection { get; private set; }
    void Start()
    {
        transform.hasChanged = false;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.hasChanged) {
            moveDirection = (transform.position - lastPosition).normalized;
            lastPosition = transform.position;
        }
    }
}
