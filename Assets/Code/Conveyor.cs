using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float force;

    public void OnCollisionStay(Collision collision)
    {
        var rigidbodyCube = collision.collider.GetComponent<Rigidbody>();
        var velocityCube = rigidbodyCube.linearVelocity;
        var velocityDirection = direction * speed * force;
        
        rigidbodyCube.AddForce(velocityDirection - velocityCube, ForceMode.Force);
    }
}
