//Helpful tutorial from here: https://www.youtube.com/watch?v=f-oSXg6_AMQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogScript : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private KeyCode space = KeyCode.Space;
    public GameObject textBackground;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

   // what the hell is this
   IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(space) == true && textDisplay.text == sentences[index])
        {
            NextSentence();
        }
    }

    //function for moving to the next sentence
    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            textBackground.SetActive(false);

        }
    }

}
