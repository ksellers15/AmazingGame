using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DistanceChange : MonoBehaviour
{

    public GameObject player;
    public Image color;
    public GameObject destination;

    public float distance;
    public float maxDist;


    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        color = GetComponent<Image>();
        color.color = Color.red;
        destination = GameObject.FindGameObjectWithTag("Destination");
        maxDist = Vector3.Distance(player.transform.position, destination.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        distance = Vector3.Distance(player.transform.position, destination.transform.position);
        ChangeColor();
    }

    public void ChangeColor()
    {

        if (distance <= maxDist / 1.5) // if distance drops below a little more than half change from red to yellow
        {
            color.color = Color.Lerp(Color.red, Color.yellow, 1);
            if (distance <= maxDist / 3.5) // if distance drops below a forth of the distance change from yellow to green
            {
                color.color = Color.Lerp(Color.yellow, Color.green, 1);
                if (distance > maxDist / 3.5) // if distance rises above a forth of the distance change from green to yellow
                {
                    color.color = Color.Lerp(Color.green, Color.yellow, 1);
                }
            }
        }

        else // if its not yellow or green, its red
        {
            color.color = Color.Lerp(Color.yellow, Color.red, 1);
        }
    }
}
