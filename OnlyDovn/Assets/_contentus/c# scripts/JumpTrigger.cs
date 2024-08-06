using DiasGames.Controller;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] float newJumpHeight = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CSPlayerController>().JumpOnBed(newJumpHeight);
        }
    }
}
