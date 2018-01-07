using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject player;
    public GameObject UI;
    public UIController uiController;

    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
        uiController = UI.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            uiController.WinScreen();
        }
    }
}
