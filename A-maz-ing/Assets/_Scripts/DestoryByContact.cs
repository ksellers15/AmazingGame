using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{

    public GameObject player;
    public GameObject BackGround;
    public Renderer rend;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        BackGround = GameObject.FindGameObjectWithTag("Background");
        rend = BackGround.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            rend.material.SetColor("Red", Color.black);
            Destroy(this.gameObject);
        }

    }
}
