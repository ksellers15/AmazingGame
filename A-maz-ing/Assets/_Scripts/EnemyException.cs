using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyException : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        enemy = GameObject.FindGameObjectWithTag("Enemy");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
            return;
    }
}
