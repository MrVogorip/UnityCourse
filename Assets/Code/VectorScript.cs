using UnityEngine;

public class VectorScript : MonoBehaviour
{
    public Vector2 VectorA;
    public Vector2 VectorB;
    [Range(0, 1)]
    public float T;
    
    void Start()
    {
        Debug.Log(VectorA.magnitude);
        Debug.Log(VectorA.normalized);
        Debug.Log(VectorB + VectorA);
        Debug.Log(VectorB - VectorA);
        Debug.Log(VectorB * VectorA);
        Debug.Log(VectorB / VectorA);
        
        Debug.Log(Vector2.Dot(VectorA, VectorB));
        Debug.Log(Vector2.Angle(VectorA, VectorB));
        
        Debug.Log(Vector2.Distance(VectorA, VectorB));
        
        Debug.Log(Vector2.Lerp(VectorA, VectorB, T));
    }

    void Update()
    {
        Debug.Log(Time.deltaTime);
    }
}
