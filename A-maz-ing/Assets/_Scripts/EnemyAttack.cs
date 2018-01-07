using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject self;
    public EnemyMovement eNM;

    // Use this for initialization
    void Awake()
    {
        eNM = self.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            eNM.Attack();
        }
        else
            return;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            eNM.nav.isStopped = false;
            eNM.anim.SetBool("pIR", false);
        }
        else
            return;
    }

}
