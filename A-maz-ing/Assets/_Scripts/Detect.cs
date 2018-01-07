using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{

    public GameObject player;
    public GameObject self;
    public EnemyMovement eNM;
    public bool seePlayer;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eNM = self.GetComponent<EnemyMovement>();
        seePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (seePlayer)
        {
            eNM.ChasePlayer();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            seePlayer = true;
        }
        else
            return;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            seePlayer = false;
            eNM.StartCoroutine(eNM.Wait());
        }
        else
            return;
    }
}
