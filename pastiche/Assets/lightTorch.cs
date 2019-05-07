using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTorch : MonoBehaviour
{
    public bool torchLit = false;
    public GameObject player;
    public Animator torchAnimator;
    public int torchNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        torchAnimator.SetBool("torchAnimateBool",false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collided with torch");
        if (collider.gameObject.CompareTag("Player") && (torchLit == false))
        {
            InputManager inputManager = player.GetComponent<InputManager>();
            inputManager.jumpForce = inputManager.jumpForce + 4;
            torchLit = true;
            torchAnimator.SetBool("torchAnimateBool", true);
            Debug.Log("jumpforce is "+ inputManager.jumpForce);
            torchNumber = torchNumber + 1;
        }
    }

    void FixedUpdate()
    {

    }
}