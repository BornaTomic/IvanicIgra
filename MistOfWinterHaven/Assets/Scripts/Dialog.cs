using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;
    public static bool canType = false;
    public string[] senteces;
    public static int index;
    public float typingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canType)
        {
            StartCoroutine(Type());
            canType = false;
        }
        if (index == NPC.index)
        {
            continueButton.SetActive(false);
        }
        if (textDisplay.text == senteces[index] && NPC.isStart)
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in senteces[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < senteces.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = senteces[index];
        }
    }
}
