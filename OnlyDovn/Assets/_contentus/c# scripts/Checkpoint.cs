using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCheckpoint>().SetCheckpoint(transform.position);
            TurnOfCheckPoint();
        }
    }

    private void TurnOfCheckPoint()
    {
        gameObject.SetActive(false);
    }
}
