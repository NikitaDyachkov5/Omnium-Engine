using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform target;

    [Header("Position")]
    [SerializeField]
    private float height = 8f;
    [SerializeField]
    private float distance = 6f;

    [Header("Movement")]
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Rotation")]
    [SerializeField] private float lookAngle = 45f;
    
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 forward = target.forward;

        Vector3 desiredPosition = target.position - forward * distance + Vector3.up * height + target.right * 0f;

        transform.position = Vector3.Lerp( transform.position, desiredPosition, smoothSpeed * Time.deltaTime );

        Quaternion rotation = Quaternion.Euler( lookAngle, target.eulerAngles.y, 0f );

        transform.rotation = Quaternion.Lerp( transform.rotation, rotation, smoothSpeed * Time.deltaTime );

    }
}
