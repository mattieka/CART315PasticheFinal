using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    // allows speed to be fiddled with in the inspector
    public float speed;

    // allows jump force to be fiddled with in the inspector
    public float jumpForce;

    // detects whether or not a key for movement is being pressed.
    private float moveInput;

    // lets me mess with rigidbody from the script editor when called in start function
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    // called every set number of frames
    void FixedUpdate()
    {
        // unity detects if the left or right arrow keys are being pressed.
        // variable moveInput gets set to -1 if the LEFT arrow key is pressed.
        // variable moveInput gets set to 1 if the RIGHT arroy key is pressed.
        moveInput = Input.GetAxis("Horizontal");

        // set's characters rigidbody velocity (essentially the same as speed)
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

}
