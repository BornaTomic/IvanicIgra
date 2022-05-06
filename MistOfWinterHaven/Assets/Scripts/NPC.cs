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
    public TextMeshProUGUI textDisplay;
    //public GameObject quest;
    public GameObject dialogManager;
    bool isCollision = false;
    bool isDone = false;
    public static bool isStart = false;
    public static int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision && !isDone)
        {
            Dialog.canType = true;
            tekstOdNpca.SetActive(true);
            index = 0;
            dialogManager.GetComponent<Dialog>().senteces[0] = "Help! Help!";
            Dialog.index = 0;
            continueButton.SetActive(false);
            odg1.SetActive(true);
            zavrKonv.SetActive(true);
            dialogBox.SetActive(true);
            tekst.SetActive(false);
            continueButton.SetActive(true);
            isStart = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tekst.SetActive(true);
            isCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
        Dialog.index = 0;
        textDisplay.text = "";
        Dialog.canType = true;
        index = 2;
        dialogManager.GetComponent<Dialog>().senteces[0] = "A tall knight has taken my beloved gem...";
        dialogManager.GetComponent<Dialog>().senteces[1] = "...and he is refusing to give it back,...";
        dialogManager.GetComponent<Dialog>().senteces[2] = "...can you help me return it back.";
        odg2.SetActive(true);
        odg1.SetActive(false);
    }

    public void Odg2()
    {
        continueButton.SetActive(true);
        Dialog.index = 0;
        Dialog.canType = true;
        index = 1;
        dialogManager.GetComponent<Dialog>().senteces[0] = "Thank you,...";
        dialogManager.GetComponent<Dialog>().senteces[1] = "...I will give you reward if you return it";
        dialogManager.GetComponent<Dialog>().senteces[2] = "";
        odg2.SetActive(false);
        zavrKonv.SetActive(false);
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
    }
}
