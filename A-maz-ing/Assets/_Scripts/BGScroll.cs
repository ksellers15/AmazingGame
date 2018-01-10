using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float scrollSpeed;
    public float someLength;
    private Vector3 startPosition;
    public SpawnEnemies spawnEnemies;
    // Use this for initialization
    void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnEnemies.start)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, someLength);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
	}
}
