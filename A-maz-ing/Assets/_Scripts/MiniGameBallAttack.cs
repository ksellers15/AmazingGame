using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBallAttack : MonoBehaviour
{
    public MiniGameUIController miniGameUI;
    public SpawnEnemies spawnEnemies;
    public Rigidbody rb;
    public int damage;
    public AudioSource hit;
    public int score;
    public bool inBox;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            rb.AddForce(0, 10, 0, ForceMode.Impulse);
            hit.Play();
            score += 15;
        }
        if (other.tag == "LeftWall")
        {
            rb.AddForce(5, 5, 0, ForceMode.Impulse);
            hit.Play();
            if(spawnEnemies.start)
                score += 20;
        }
        if (other.tag == "RightWall")
        {
            rb.AddForce(-5, 5, 0, ForceMode.Impulse);
            hit.Play();
            if(spawnEnemies.start)
                score += 20;
        }
        if(other.tag == "Safe")
        {
            inBox = true;
            score += 50;
        }
        miniGameUI.UpdateScore();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
