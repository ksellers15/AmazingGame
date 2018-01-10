using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public SpawnEnemies spawnEnemies;
    public MiniGameMovement miniGM;

    public bool side;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemies.start && side)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (spawnEnemies.start)
        {
            if (other.tag == "Player")
            {
                miniGM.isGrounded = false;
                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            miniGM.isGrounded = false;
            Destroy(this.gameObject);
        }
    }
}
