using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickReceiver : MonoBehaviour
{
    private GameObject player;
    private Joystick joy;

    public bool IsCameraJoystick;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        joy = GetComponent<Joystick>();
    }

    
    void Update()
    {
        if (IsCameraJoystick)
            player.SendMessage("OnLook", new Vector2(joy.Horizontal, joy.Vertical));
        else
            player.SendMessage("OnMove", new Vector2(joy.Horizontal, joy.Vertical));
    }
}
