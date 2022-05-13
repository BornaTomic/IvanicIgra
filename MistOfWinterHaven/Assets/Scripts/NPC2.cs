using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC2 : MonoBehaviour
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
    GameObject gameManager;
    //public GameObject quest;
    bool isCollision = false;
    bool isDone = false;
    public static bool isStart = false;
    public static int a = 0;
    GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision && !isDone && !isStart)
        {
            inventory.SetActive(false);
            dialogManager.SetActive(true);
            Dialog.canType = true;
            tekstOdNpca.SetActive(true);
            Dialog.senteces = new string[1];
            textDisplay.text = "";
            a = 0;
            Dialog.senteces[0] = "Hello, did you get the gem back?";
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
            inventory.SetActive(true);
            isStart = false;
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
        Dialog.senteces = new string[1];
        Dialog.index = 0;
        textDisplay.text = "";
        a = 0;
        Dialog.canType = true;
        Dialog.senteces[0] = "Oh, thats great,thank you so much.";
        odg2.SetActive(true);
        odg1.SetActive(false);
    }

    public void Odg2()
    {
        Dialog.senteces = new string[1];
        Dialog.index = 0;
        textDisplay.text = "";
        Dialog.canType = true;
        a = 0;
        Dialog.senteces[0] = "Ok, see you.";
        odg2.SetActive(false);
        zavrKonv.SetActive(false);
        StartCoroutine(EndKonv());
        isDone = true;
    }
    public void ZavrKonv()
    {
        inventory.SetActive(true);
        isStart = false;
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
        isStart = false;
        inventory.SetActive(true);
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
        gameManager.GetComponent<GameManager>().MainMenu();
    }
}
