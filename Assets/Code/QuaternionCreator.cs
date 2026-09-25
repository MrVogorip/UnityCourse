using UnityEngine;

public class QuaternionCreator : MonoBehaviour
{
    public GameObject Sphere;
    public Vector3 EulerTarget = new Vector3(30, 45, 60);

    public void Start()
    {
        Sphere.transform.rotation = Quaternion.Euler(EulerTarget);
        var rot = Sphere.transform.rotation;
        Debug.Log($"X={rot.x}\tY={rot.y}\tZ={rot.z}\tW={rot.w}");
        Sphere.transform.rotation = Custom(EulerTarget.y, EulerTarget.x, EulerTarget.z);
        var rot2 = Sphere.transform.rotation;
        Debug.Log($"X={rot2.x}\tY={rot2.y}\tZ={rot2.z}\tW={rot2.w}");
    }

    public static Quaternion Custom(float Y, float X, float Z)
    {
        float hy = Y * (Mathf.PI / 180.0f) * 0.5f;
        float hx = X * (Mathf.PI / 180.0f) * 0.5f; 
        float hz = Z * (Mathf.PI / 180.0f) * 0.5f;
        float cy = Mathf.Cos(hy);
        float sy = Mathf.Sin(hy);
        float cx = Mathf.Cos(hx);
        float sx = Mathf.Sin(hx);
        float cz = Mathf.Cos(hz);
        float sz = Mathf.Sin(hz);
        float x = cy * sx * cz + sy * cx * sz;
        float y = sy * cx * cz - cy * sx * sz;
        float z = cy * cx * sz - sy * sx * cz;
        float w = cy * cx * cz + sy * sx * sz;
        return new Quaternion(x, y, z, w).normalized;
    }

}
