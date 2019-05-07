using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shroomSignText : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private KeyCode space = KeyCode.Space;
    public GameObject textBackground;
    private bool signActive = false;

     //{ "WARNING: \n", "Watch out for scrambleshrooms! \n", "Even the lightest touch can make you dizzy. \n", "If you find yourself disoriented, seek out the stars to light your way. \n" }
    // Start is called before the first frame update
    void Start()
    {
        sentences[0] = "WARNING: \n";
        sentences[1] = "Watch out for scrambleshrooms! \n";
        sentences[2] = "Even the lightest touch can make you dizzy. \n";
        sentences[3] = "If you find yourself disoriented, seek out the stars to light your way. \n";
    }

    // what the hell is this
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (index == 0 && collision.gameObject.CompareTag("Player") && Input.GetKeyDown("space") == true)
        {
            Debug.Log("COLLIDED");
            signActive = true;
            textBackground.SetActive(true);
            if (index == 0)
            {
                StartCoroutine(Type());
            }

        }
    }

    void Update()
    {
        if (signActive == true && textDisplay.text == sentences[0])
        {
            NextSentence();
        }
    }

    //function for moving to the next sentence
    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            sentences[0] = sentences[0] + sentences[index + 1];
            Debug.Log(sentences[0]);
            Debug.Log(index);
            index++;
            StartCoroutine(Type());
        }
        else if (index >= sentences.Length - 1 && Input.GetKeyDown("space") == true)
        {
            textDisplay.text = "";
            textBackground.SetActive(false);
            signActive = false;
            index = 0;
            sentences[0] = "WARNING: \n";
        }
    }

}