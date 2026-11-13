using UnityEngine;

public class BoxController : MonoBehaviour
{
    public AudioSource Drop;
    public Rigidbody Rigidbody;
    public float ForceScale;
    public float TorqueScale;
    
    private bool isDropped;
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isDropped)
            return;
        
        isDropped = true;
        Drop.Play();
        Rigidbody.AddForce(Vector3.up * Random.value * ForceScale, ForceMode.Impulse);
        Rigidbody.AddTorque(Random.onUnitCircle * TorqueScale, ForceMode.Impulse);
    }

    public void Selected()
    {
        material.SetFloat("_OutlineWidth", 0.03f);
    }

    public void Deselected()
    {
        material.SetFloat("_OutlineWidth", 0.00f);
    }
}
