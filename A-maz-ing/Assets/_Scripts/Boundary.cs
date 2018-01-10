using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    public SpawnEnemies spawnEnemies;
    //public SpawnEnemies spawnEnemies;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           spawnEnemies.Lose();
        }
        Destroy(other.gameObject);
    }
}
