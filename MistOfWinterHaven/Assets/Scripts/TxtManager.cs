using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<LeteciTextDoslovno> leteciTextovi = new List<LeteciTextDoslovno>(); //LISTA!!

    private void Update()
    {
        foreach (LeteciTextDoslovno txt in leteciTextovi)  //For each petlja ako se sjecas prve godine, ak ne imas internet neda mi se pisat 
        {
            txt.UpdateTxt();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 kretnja, float trajanje)
    {
        LeteciTextDoslovno letecitxt = DohvatiTxt(); //moze biti novi a i stari txt

        letecitxt.txt.text = msg;  //Holy shit gle ime ti tu sve kaze sta je sta malo logike samo
        letecitxt.txt.fontSize = fontSize;//Prvi txt je komponenta usput?
        letecitxt.txt.color = color;

        letecitxt.go.transform.position = Camera.main.WorldToScreenPoint(position); //Stavljamo poziciju preko kamere, ovo world to screen point ti je znaci imas dvoje kordinata, world i scene, ukratko ovaj kod dobar inace ne dobro nemos u UI koristit inace
        letecitxt.kretnja = kretnja;
        letecitxt.trajanje = trajanje;

        letecitxt.Show();//pozivamo Show 

    }

    private LeteciTextDoslovno DohvatiTxt()    //Kratko i lagano, ovdije samo radimo na dohvacanju zeljenoga teksta
    {
        LeteciTextDoslovno txt = leteciTextovi.Find(t => !t.active);  //Kopanje po listi i trazenje ne aktivnog zato je tu !

        if (txt == null)  //Ako je txt prazan, nepostojec, cini sljedece
        {
            txt = new LeteciTextDoslovno();
            txt.go = Instantiate(textPrefab); //Instanciranje textPrefaba
            txt.go.transform.SetParent(textContainer.transform);//Dajemo textContainer kao tatu ovom
            txt.txt = txt.go.GetComponent<Text>(); //Gle nemas potrebe tu puno komentirat

            leteciTextovi.Add(txt); //Ovdje ostavljamo ako je potreban kasnije
        }

        return txt; //Ako smo gore nasli nesta, preskacemo if do ovdije, ako nismo idemo kroz if i dodjemo ovdje
    }
}
