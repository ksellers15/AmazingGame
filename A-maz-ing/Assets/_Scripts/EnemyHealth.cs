using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public GameObject self;
    public int health;
    public EnemyMovement eNM;
    public bool dead;
    public AudioSource death;

    // Use this for initialization
    void Awake()
    {

        health = 100;
        eNM = self.GetComponent<EnemyMovement>();
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            dead = true;
            StartCoroutine(eNM.Death());
            death.Play();
            //StartCoroutine(Death());
        }
    }
}
