using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healStar : MonoBehaviour
{
    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collided with star");
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<InputManager>().ResetControls();
            Debug.Log("controls reset");
            timer = 60;

        }
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            this.transform.Rotate(new Vector3(0, 0, 20));
            timer--;
        }
    }
}