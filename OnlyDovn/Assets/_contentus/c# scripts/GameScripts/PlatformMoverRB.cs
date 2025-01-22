using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverRB : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    public float delay = 1.0f;

    private Rigidbody rb;
    private bool isStay = true;
    private bool movingToB = true;

    CharacterController cc;
    Transform target;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetNewTarget();
    }

    private void FixedUpdate()
    {
        if (!isStay)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, target.position, speed));
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                isStay = true;
                Invoke("SetNewTarget", delay);
            }

        }
    }

    void SetNewTarget()
    {
        isStay = false;
        movingToB = !movingToB;
        target = movingToB ? pointB : pointA;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cc = other.GetComponent<CharacterController>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }
}
