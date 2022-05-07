using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject tekst;
    public GameObject tekstOdNpca;
    public GameObject odg1;
    public GameObject odg2;
    public GameObject zavrKonv;
    public GameObject dialogBox;
    public GameObject continueButton;
    public GameObject dialogManager;
    public TextMeshProUGUI textDisplay;
    //public GameObject quest;
    bool isCollision = false;
    bool isDone = false;
    public static bool isStart = false;
    public static int a = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision && !isDone)
        {
            dialogManager.SetActive(true);
            Dialog.canType = true;
            tekstOdNpca.SetActive(true);
            Dialog.senteces = new string[1];
            textDisplay.text = "";
            a = 0;
            Dialog.senteces[0] = "Help! Help!";
            Dialog.index = 0;
            continueButton.SetActive(false);
            odg1.SetActive(true);
            zavrKonv.SetActive(true);
            dialogBox.SetActive(true);
            tekst.SetActive(false);
            isStart = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDone)
        {
            tekst.SetActive(true);
            isCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogManager.SetActive(false);
            tekst.SetActive(false);
            isCollision = false;
            tekstOdNpca.SetActive(false);
            odg1.SetActive(false);
            zavrKonv.SetActive(false);
            dialogBox.SetActive(false);
            continueButton.SetActive(false);
        }
    }
    public void Odg1()
    {
        Dialog.senteces = new string[3];
        Dialog.index = 0;
        textDisplay.text = "";
        a = 2;
        Dialog.canType = true;
        Dialog.senteces[0] = "A tall knight has taken my beloved gem...";
        Dialog.senteces[1] = "...and he is refusing to give it back,...";
        Dialog.senteces[2] = "...can you help me return it back.";
        odg2.SetActive(true);
        odg1.SetActive(false);
    }

    public void Odg2()
    {
        Dialog.senteces = new string[2];
        Dialog.index = 0;
        textDisplay.text = "";
        Dialog.canType = true;
        a = 1;
        Dialog.senteces[0] = "Thank you,...";
        Dialog.senteces[1] = "...I will give you reward if you return it.";
        odg2.SetActive(false);
        zavrKonv.SetActive(false);
        StartCoroutine(EndKonv());
        isDone = true;
    }
    public void ZavrKonv()
    {
        Dialog.index = 0;
        textDisplay.text = "";
        tekst.SetActive(false);
        isCollision = false;
        tekstOdNpca.SetActive(false);
        odg1.SetActive(false);
        odg2.SetActive(false);
        zavrKonv.SetActive(false);
        dialogBox.SetActive(false);
        continueButton.SetActive(false);
        dialogManager.SetActive(false);
    }

    IEnumerator EndKonv()
    {
        yield return new WaitForSeconds(10f);
        Dialog.index = 0;
        textDisplay.text = "";
        tekst.SetActive(false);
        isCollision = false;
        tekstOdNpca.SetActive(false);
        odg1.SetActive(false);
        odg2.SetActive(false);
        zavrKonv.SetActive(false);
        dialogBox.SetActive(false);
        continueButton.SetActive(false);
        dialogManager.SetActive(false);
    }
}
