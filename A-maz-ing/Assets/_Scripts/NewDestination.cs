using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NewDestination : MonoBehaviour
{

    //public GameObject enemy;
    //public float timeBetween = 6f;
    public EnemyMovement eNM;

    //private float timer;
    //private Transform destination;

    public NavMeshAgent nav;

    // Use this for initialization
    void Awake()
    {

        //eNM = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        //nav = eNM.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    public void Update()
    {

    }

    /*void OnTriggerEnter(Collider other)
    {
            nav = other.gameObject.GetComponent<NavMeshAgent>();
            eNM = other.GetComponent<EnemyMovement>();
            eNM.StartCoroutine(eNM.Wait());

    }*/

    public IEnumerable NewDest()
    {
        Debug.Log("Moving");
        nav.isStopped = true;
        nav.ResetPath();
        yield return new WaitForSeconds(4);
        eNM.Move(Random.Range(0, 5));
    }
}
