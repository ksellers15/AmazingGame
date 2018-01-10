using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public GameObject enemy;
    public EnemyHealth eh;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        eh = enemy.GetComponent<EnemyHealth>();
        rb.GetComponent<Rigidbody>();
        rb.velocity = transform.up*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("HIT");
            eh = other.gameObject.GetComponent<EnemyHealth>();
            eh.health -= 20;
        }
        Destroy(this.gameObject);

    }


}
