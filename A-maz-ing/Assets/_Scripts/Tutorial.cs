using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public Canvas tutorial;
    public GameObject player;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tutorial.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1.0f;
            tutorial.enabled = false;
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0.0f;
        if (other.gameObject == player)
        {
            tutorial.enabled = true;
        }
    }
}
