using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konverzacija : MonoBehaviour
{
    public GameObject tekst;
    public GameObject tekst2;
    public GameObject tekst3;
    public GameObject textKonv;
    public GameObject odg1;
    public GameObject odg2;
    public GameObject zavrKonv;
    public bool isInCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            textKonv.SetActive(true);
            tekst.SetActive(false);
            odg1.SetActive(true);
            zavrKonv.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tekst.SetActive(true);
            isInCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tekst.SetActive(false);
            textKonv.SetActive(false);
            odg1.SetActive(false);
            zavrKonv.SetActive(false);
            tekst3.SetActive(false);
            isInCollision = false;
        }
    }
    public void ZavrKonv()
    {
        tekst.SetActive(false);
        textKonv.SetActive(false);
        odg1.SetActive(false);
        zavrKonv.SetActive(false);
        isInCollision = false;
    }
    public void Odg1()
    {
        tekst.SetActive(false);
        odg1.SetActive(false);
        textKonv.SetActive(false);
        tekst2.SetActive(true);
        zavrKonv.SetActive(false);
        odg2.SetActive(true);
        odg1.SetActive(false);
    }
    public void Odg2()
    {
        tekst.SetActive(false);
        odg1.SetActive(false);
        textKonv.SetActive(false);
        tekst2.SetActive(false);
        zavrKonv.SetActive(false);
        tekst3.SetActive(true);
        odg2.SetActive(false);
    }
}
