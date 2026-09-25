using UnityEngine;

public class RotatorController : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private Transform cube;
    
    public void Start()
    {
        cube = GetComponent<Transform>();
    }

    public void Update()
    {
        cube.Rotate(direction * (speed * Time.deltaTime));
    }
}