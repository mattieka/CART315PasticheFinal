using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hello????");
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<InputManager>().ChangeControls();
            Debug.Log("collideeeee");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
