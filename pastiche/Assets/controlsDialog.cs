//Helpful tutorial from here: https://www.youtube.com/watch?v=f-oSXg6_AMQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlsDialog : MonoBehaviour
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
        sentences[0] = "CONTROLS: \n";
        sentences[1] = "Left and Right arrows to move. \n";
        sentences[2] = "Up arrow to jump. Shift to run. \n";
        sentences[3] = "Space to advance dialog. \n";
        sentences[4] = "When you've lit all 5 torches, you win.\n";

        textBackground.SetActive(true);
        StartCoroutine(Type());
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

    void Update()
    {
        if (textDisplay.text == sentences[0])
        {
            NextSentence();
        }
    }

    //function for moving to the next sentence
    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            sentences[0] = sentences[0] + sentences[index+1];
            Debug.Log(sentences[0]);
            Debug.Log(index);
            index++;
            StartCoroutine(Type());
        }
        else if (index >= sentences.Length-1 && Input.GetKeyDown("space") == true)
        {
            textDisplay.text = "";
            textBackground.SetActive(false);
        }
    }

}
