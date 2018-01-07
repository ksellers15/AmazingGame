using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{

    public GameObject player;
    public GameObject GameController;
    public GameController gameController;

    public AudioSource pickup;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = GameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pickup.Play();
            Destroy(this.gameObject);
        }

    }
}
