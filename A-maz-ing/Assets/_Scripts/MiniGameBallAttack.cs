using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBallAttack : MonoBehaviour
{
    public MiniGameUIController miniGameUI;
    public SpawnEnemies spawnEnemies;
    public MiniGameMovement miniGM;
    public Rigidbody rb;
    public int damage;
    public AudioSource hit;
    public AudioSource box;
    public AudioSource pickUp;
    public int score;
    public bool inBox;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        miniGM = GetComponent<MiniGameMovement>();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            rb.AddForce(0, miniGM.jumpH + 6 , 0, ForceMode.Impulse);
            hit.Play();
            score += 15;
        }
        if (other.tag == "LeftWall")
        {
            rb.AddForce(5, 5, 0, ForceMode.Impulse);
            hit.Play();
            if (spawnEnemies.start)
                score += 20;
        }
        if (other.tag == "RightWall")
        {
            rb.AddForce(-5, 5, 0, ForceMode.Impulse);
            hit.Play();
            if (spawnEnemies.start)
                score += 20;
        }
        if (other.tag == "Safe")
        {
            inBox = true;
            box.Play();
            score += 50;
        }
        if(other.tag == "PickUp")
        {
            pickUp.Play();
            score += 100;
        }
        miniGameUI.UpdateScore();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
