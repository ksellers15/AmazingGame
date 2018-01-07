using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public GameObject player;
    public PlayerMovement pm;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        camera2.enabled = false;
        camera1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.inverted)
        {
            camera2.enabled = true;
            camera1.enabled = false;
        }
        else
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }
}
