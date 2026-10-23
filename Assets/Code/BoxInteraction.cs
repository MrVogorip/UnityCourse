using UnityEngine;
using UnityEngine.InputSystem;

public class BoxInteraction : MonoBehaviour
{
    public GameObject BoxPlaceholder;
    public Vector3 RayOffset;
    public float Distance;
    public float ThrowForce;
    
    private BoxController boxController;
    private InputAction interact; 
    
    public bool HasBox => boxController != null;
    
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            if (boxController == null)
            {
                TryGetBox();
            }
            else
            {
                ThrowBox();
            }
        }
    }

    private void ThrowBox()
    {
        boxController.transform.SetParent(null);
        boxController.Rigidbody.isKinematic = false;
        boxController.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        boxController.GetComponent<BoxCollider>().enabled = true;
        boxController.Rigidbody.AddForce(transform.forward * ThrowForce, ForceMode.Impulse);
        boxController = null;
    }

    private void TryGetBox()
    {
        Vector3 startPosition = transform.position + RayOffset;

        if (Physics.Raycast(startPosition, transform.forward * Distance, out RaycastHit hitInfo))
        {
            var box = hitInfo.transform.gameObject.GetComponent<BoxController>();
            if (box == null)
                return;
            
            boxController = box;
            boxController.transform.SetParent(BoxPlaceholder.transform);
            
            hitInfo.rigidbody.isKinematic = true;
            hitInfo.rigidbody.interpolation = RigidbodyInterpolation.None;
            hitInfo.collider.enabled = false;
            boxController.enabled = false;
            boxController.GetComponent<RotatorController>().enabled = false;
            boxController.transform.localPosition = Vector3.zero;
            boxController.transform.localRotation = Quaternion.identity;
        }
    }

    public void OnDrawGizmos()
    {
        Vector3 startPosition = transform.position + RayOffset;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(startPosition, transform.forward * Distance);
    }
}
