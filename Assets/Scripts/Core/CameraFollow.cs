using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Transform))]
public class CameraFollow : MonoBehaviour
{
    [Tooltip("The target object that the camera will follow.")]
    public Transform target;

    [Tooltip("The smoothing value used to smooth the camera's movement.")]
    public float smoothing = 5.0f;

    [Tooltip("The minimum distance between the camera and the target object.")]
    public float minDistance = 1.0f;

    [Tooltip("The maximum distance between the camera and the target object.")]
    public float maxDistance = 10.0f;

    [Tooltip("The minimum angle between the camera and the target object.")]
    public float minAngle = -45.0f;

    [Tooltip("The maximum angle between the camera and the target object.")]
    public float maxAngle = 45.0f;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        Vector3 direction = targetCamPos - target.position;
        float distance = Mathf.Clamp(direction.magnitude, minDistance, maxDistance);
        direction.Normalize();
        float angle = Mathf.Clamp(Vector3.Angle(transform.forward, direction), minAngle, maxAngle);
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(angle, 0, 0);
        transform.position = Vector3.Lerp(transform.position, target.position + rotation * Vector3.back * distance, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothing * Time.deltaTime);
    }
}