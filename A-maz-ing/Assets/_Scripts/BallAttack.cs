using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : MonoBehaviour
{

    public Rigidbody rb;
    public int damage;
    public AudioSource hit;
    public int score;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            rb.AddForce(0, 3, 0, ForceMode.Impulse);
            hit.Play();
            score += 10;
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else
            return;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
