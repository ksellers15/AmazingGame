using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject UI;
    public UIController uiController;
    public AudioSource jumpSound;
    public GameObject gc;
    public GameController gameController;

    public bool isGrounded;
    public bool dead;
    public bool inverted = false;


    public Rigidbody rb;
    public int speed;
    public int health;

    private float x = 1;
   

    // Use this for initialization
    void Awake()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        uiController = UI.GetComponent<UIController>();
        rb = GetComponent<Rigidbody>();
        gc = GameObject.FindGameObjectWithTag("GameController");
        gameController = gc.GetComponent<GameController>();
        health = 100;
    }

    public void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if (Input.GetKeyDown(KeyCode.N))
        {
            Invert();
        }

        if (!uiController.isWin && !uiController.isLose)
        {
            rb.AddForce(x *movement * speed);
            Jump();
        }
        
    }

    void Jump()
    {
        Vector3 jump = new Vector3(0, 5, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump, ForceMode.Impulse);
            jumpSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    // Update is called once per frame
    void Update () {
        if(health<=0)
        {
            dead = true;
        }
		
	}

    void Invert()
    {
        if (!inverted)
        {
            x = -1;
            inverted = true;
        }
        else
        {
            x = 1;
            inverted = false;
        }
    }
}
