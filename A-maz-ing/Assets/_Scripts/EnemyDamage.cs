﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int hit;
    public GameObject player;
    public PlayerMovement pm;
    public GameObject head;
    public EnemyHealth eH;
    public float timeBetweenAttacks = 0.5f;
    public bool playerInRange;

    private float timer;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        eH = head.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && !eH.dead) /* && enemyHealth.currentHealth > 0*/
        {
            Attack();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (pm.health > 0)
        {
            pm.health -= hit;
        }
    }
}
