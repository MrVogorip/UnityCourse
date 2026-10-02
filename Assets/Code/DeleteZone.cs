using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        var cube = other.gameObject;
        Destroy(cube);
    }
}
