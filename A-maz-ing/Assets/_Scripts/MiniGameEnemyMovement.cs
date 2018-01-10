using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    
    void Awake()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            return;
        if(other.tag == "Player" || other.tag == "Safe")
            Destroy(this.gameObject);
    }
}
