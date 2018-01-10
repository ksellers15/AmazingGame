using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Shot;
    public AudioSource shoot;
    public float fireRate = .30f;
    private float myTime, nextFire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireRate;
            Instantiate(Bullet, Shot.position, Shot.rotation);
            shoot.Play();
        }
    }
}
