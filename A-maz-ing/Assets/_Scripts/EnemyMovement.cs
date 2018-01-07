using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent nav;
    public Animator anim;
    public EnemyHealth eH;
    public GameObject[] destinations;
    public Vector3 finalDestination;
    public int num;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        num = Random.Range(0, destinations.Length);
        Move(num);
    }
    

    void FixedUpdate()
    {
        if (this.transform.position == destinations[num].transform.position || transform.position == finalDestination)
        {
            StartCoroutine(Wait());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "EDestination")
        {
            StartCoroutine(Wait());
        }
    }

    public void Move(int num)
    {
        if (!eH.dead)
        {
            nav.ResetPath();
            nav.speed = .75f;
            finalDestination = destinations[num].transform.position;
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            Debug.Log(num);
            nav.SetDestination(finalDestination);
        }
    }

    public IEnumerator Wait()
    {
        if (!eH.dead)
        {
            nav.isStopped = true;
            anim.SetBool("isIdle", true);
            num = Random.Range(0, destinations.Length);
            yield return new WaitForSeconds(3);
            Move(num);
        }
    }

    public void ChasePlayer()
    {
        if (!eH.dead)
        {
            anim.SetBool("isRunning", true);
            nav.speed = 4;
            finalDestination = player.transform.position;
            nav.SetDestination(finalDestination);
        }
    }

    public void Attack()
    {
        nav.isStopped = true;
        anim.SetBool("pIR", true);
    }

    public IEnumerator Death()
    {
        nav.isStopped = true;
        anim.SetTrigger("isDead 0");
        Flatten();
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }


    public void Flatten()
    {
        transform.localScale -= new Vector3(-.6F, 1f, -.6f);
    }
}
