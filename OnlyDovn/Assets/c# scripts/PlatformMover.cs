using System.Collections;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Vector3 pointA = new Vector3(0, 0, 0);
    public Vector3 pointB = new Vector3(0, 0, 10);
    public float speed = 2.0f;
    public float delay = 1.0f;

    private bool movingToB = true;

    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 target = movingToB ? pointB : pointA;
            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); //Lerp(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(delay);
            movingToB = !movingToB;
        }
    }
}

