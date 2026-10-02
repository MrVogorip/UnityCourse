using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnRate;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnRate)
        { 
            _timer = 0;
            Instantiate(cubePrefab, transform.position, transform.rotation);
        }
    }
}
