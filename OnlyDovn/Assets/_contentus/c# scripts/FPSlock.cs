using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSlock : MonoBehaviour
{
    [SerializeField] int targetFrameRate = 60;
    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = 0;
    }
}
