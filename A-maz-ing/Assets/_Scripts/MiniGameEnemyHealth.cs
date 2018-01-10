using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemyHealth : MonoBehaviour {

    public Rigidbody rb;
    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Die();
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        rb.velocity = transform.right;
    }
}
