using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D playerRigidBody;
    InputManager inputManager;

    public float defaultPlayerSpeed = 4f;
    public float playerSpeed;
    public bool nowRunning = false;

    void Start()
    {
        playerSpeed = defaultPlayerSpeed;
    }

    private void OnEnable()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

    }

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
       if (Input.GetKey(inputManager.runKey) == true && nowRunning == false && (inputManager.CurrentInput < 0 || inputManager.CurrentInput > 0)) {
            RunSpeed();
        }

        if (Input.GetKeyUp(inputManager.runKey) == true)
        {
            nowRunning = false;
            playerSpeed = defaultPlayerSpeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(inputManager.CurrentInput * playerSpeed, playerRigidBody.velocity.y);
    }

    internal static float GetPlayerSpeed()
    {
        throw new NotImplementedException();
    }

    void RunSpeed()
    {
        playerSpeed = playerSpeed * 2;
        nowRunning = true;
    }
}
