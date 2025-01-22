using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int CheckLock;
    private void OnTriggerEnter(Collider other)
    {
        CheckLock = 1;
        PlayerPrefs.SetInt("Unlock", CheckLock);
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
