using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisibilityOfObject : MonoBehaviour
{
    //Renderer test;
    private float dist;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        //test = GetComponent<MeshRenderer>();
        Debug.Log("Расстояние до игрока: " + dist);
        if (dist > 20)
        
        {
            gameObject.SetActive(false);
        
        }
        else 
        {
            gameObject.SetActive(true);

        }
    }
}
