using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public Camera camera1;
    public Camera camera2;
    public Camera specCam;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        camera2.enabled = false;
        camera1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(specCam.enabled == true)
        {
            camera2.enabled = false;
            camera1.enabled = false;
        }
        if (playerMovement.inverted)
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
