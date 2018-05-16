using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Slider jumpHeight;
    public float jumpH;

    public bool isGrounded;
    public AudioSource jump;

    private float moveHorizontal, moveVertical;

    // Use this for initialization
    void Start()
    {

    }

    public void ChangeJumpHeight()
    {
        jumpH = jumpHeight.value;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpH, 0, ForceMode.Impulse);
                jump.Play();
            }
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement*15);
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
}
