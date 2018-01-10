using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPlayer : MonoBehaviour
{

    public GameObject Player;

    private Vector3 offset;
    private float x, z, y;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        x = Player.transform.position.x;
        z = Player.transform.position.z;
        y = Player.transform.position.y;
        offset = new Vector3(0, 2.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position - offset;

    }
}
