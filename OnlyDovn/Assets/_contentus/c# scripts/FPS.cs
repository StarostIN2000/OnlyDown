using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{

    public float updateInterval = 0.5f; //How often should the number update
    float timeleft;
    float fps;

    TextMeshProUGUI txt;

    // Use this for initialization
    void Start()
    {
        timeleft = updateInterval;
        txt = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            fps = 1f / Time.unscaledDeltaTime;
            timeleft = updateInterval;
            txt.text = fps.ToString("F0");
        }
    }
}
