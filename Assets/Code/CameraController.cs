using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset = new  Vector3(0f, 1.5f, 0f);
    public float maxDistance = 5f;
    public float sensitivity = 0.1f;
    
    public float minPitch = -15f;
    public float maxPitch = 80f;
    
    private float yaw;
    private float pitch;
    private InputAction mouseAction;

    public void Start()
    {
        mouseAction = InputSystem.actions.FindAction("Look");
        yaw = target.eulerAngles.y;
    }

    public void LateUpdate()
    {
        var mouseVector = mouseAction.ReadValue<Vector2>();
        yaw += mouseVector.x * sensitivity;
        pitch = Mathf.Clamp(pitch - mouseVector.y * sensitivity, minPitch, maxPitch);
        
        var rotation = Quaternion.Euler(pitch, yaw, 0);
        var pivot = target.position + targetOffset;
        
        transform.rotation = rotation;
        transform.position = pivot - rotation * Vector3.forward * maxDistance;
    }
    
}
