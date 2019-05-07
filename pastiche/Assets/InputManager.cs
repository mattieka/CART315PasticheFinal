using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    //************************************************************************
    //                              TITLE
    //************************************************************************

    //************************************************************************
    //                              VARIABLES 
    //************************************************************************

   

    // ------------------------INPUT VARIABLES ---------------------------//
    public float CurrentInput;
    public Animator animator;

    //rigidbody variable
    private Rigidbody2D rb;


    #region Arrow Key Variables
    //defaults controls to left and right arrow keys
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode runKey = KeyCode.LeftShift;

    //array containing all possible keys that the controls can change to
    private KeyCode[] keyList = new KeyCode[] { KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.UpArrow,KeyCode.LeftShift};

    #endregion

    #region Jump Variables

    //amount of jumps permitted
    private int extraJumps;
    public int extraJumpsValue;

    //"strength" of jumps
    public int jumpForce;

    //float that increases gravity upon falling
    public float fallMultiplier = 2.5f;

    //float that increases gravity for low jumps
    public float lowJumpMultiplier = 2f;

    #endregion


    #region Animation Variables
    //------------------------ANIMATION VARIABLES-----------------------//

    //defaults character to facing right on load
    private bool facingRight = true;

    #endregion

    #region Ground Check Variables
    //---------------------GROUND CHECK VARIABLES------------------//

    //checks if characters feet are on the ground
    private bool isGrounded;

    //make a circle at the player's feet. if the circle is colliding w/ smth
    //then the player is touching the ground.
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    #endregion

    //************************************************************************
    //                              FUNCTIONS
    //************************************************************************
    #region Awake Function
    //------------------------AWAKE-------------------------//
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Start Function

    //------------------------START-------------------------//
    void Start()
    {
        extraJumps = extraJumpsValue;

    }

    #endregion

   

    #region Controls Change
    //-----------------------CONTROLS CHANGE----------------------//
    public void ChangeControls()
    {
        rightKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];
        leftKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];

        while (leftKey == rightKey)
        {
            leftKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];
        }

        upKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];

        while (upKey == leftKey || upKey == rightKey)
        {
            upKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];
        }

        runKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];

        while (runKey == leftKey || runKey == rightKey || runKey == upKey)
        {
            runKey = keyList[Mathf.FloorToInt(Random.Range(0, keyList.Length))];
        }

        Debug.Log("right is now " + rightKey);
        Debug.Log("left is now " + leftKey);
        Debug.Log("jump is now " + upKey);
        Debug.Log("run is now " + runKey);
    }

    #endregion

    #region Controls Reset
    //-----------------------CONTROLS RESET----------------------//
    public void ResetControls()
    {
        rightKey = KeyCode.RightArrow;
        leftKey = KeyCode.LeftArrow;
        upKey = KeyCode.UpArrow;
        runKey = KeyCode.LeftShift;
    }
    #endregion

    #region Update Function (Movement)
    //------------------------MOVEMENT UPDATE---------------------//
    //if no keys are pressed, character does not move, update checks if an 
    //arrow is currently being pressed and controls movement accordingly.
    void Update()
    {
        CurrentInput = 0;

        if (Input.GetKey(rightKey) == true)
        {
            CurrentInput = 1;

        }

        if (Input.GetKey(leftKey) == true)
        {
        
            CurrentInput = -1;

        }


        if (isGrounded == true)
        {
            extraJumps = 1;
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(upKey) == true && extraJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            extraJumps = extraJumps - 1;
        }

        if (Input.GetKey(upKey) == true)
        {
            animator.SetBool("IsJumping", true);
        }

        //gravity adjustments for jumping
        // if (we are falling), then multiply velocity by gravity and fallmultiplier-1 and time.deltatime 
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        } else if (rb.velocity.y > 0 && !Input.GetKey (upKey)) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        if (isGrounded == false)
        {
            extraJumps = 0;

        }
    }

    #endregion

    #region Fixed Update Function (Sprite Direction, Ground Checking)
    //--------------------SPRITE DIRECTION----------------------//
    //checks what way the character is facing at the moment, as well as 
    //what direction they are moving in 

    void FixedUpdate()
    {
        if (facingRight == false && CurrentInput > 0)
        {
            Flip();
        } else if (facingRight == true && CurrentInput < 0)
        {
            Flip();
        }

        animator.SetFloat("Player Speed", Mathf.Abs(CurrentInput));

        //checks if the character is "touching" the ground by testing if an 
        //invisible circle at the player's feet is overlapping with the ground

        //groundcheck.position is the x and y coord. at the player's feet
        //check radius is the radius of the circle
        //what is ground is a layer mask
        // these are all customizable through unity's inspector
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

  

    }
    #endregion

    // function to change the graphics from facing one way to another
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    


}
