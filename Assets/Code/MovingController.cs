using System.Collections;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    public Transform A;
    public Transform B;

    public float speed;

    public bool isCoroutine;
    
    private Transform cube;
    private Vector3 target;
    
    void Start()
    {
        cube = GetComponent<Transform>();
        target = B.position;
        
        if (isCoroutine) 
            StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            cube.position = Vector3.MoveTowards(cube.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(cube.position, target) < 0.01f)
            {
                if (target == B.position)
                    target = A.position;
                else
                    target = B.position;
            }

            yield return null; // new WaitForSeconds(1);
        }
    }

    void Update()
    {
        if (isCoroutine)
            return;
        
        cube.position = Vector3.MoveTowards(cube.position, target, speed * Time.deltaTime);
        
        if (Vector3.Distance(cube.position, target) < 0.01f) 
        { 
            if (target == B.position)
                target = A.position;
            else
                target = B.position;
        }
    }
}
