using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Animator anim;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

        transform.Translate(0, 0, z);

        if (z != 0)
        {
            anim.SetBool("isRunning", true);
            transform.Rotate(0, x, 0);
        }
        else
            anim.SetBool("isRunning", false);
    }
}
