using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeteciTextDoslovno // MonoBeh ovdje je obrisan  a to pomogne sa performansom
{
    public bool active;             //.
    public GameObject go;           // .
    public Text txt;              // .            OVO TU JE ZASEBNA MALA LOGIKA ZA TEKST, MISLIM DA NETREBAM POJASNJAVAT TO TOLIKO SKUZI SE ODMA O CEM SE RADI
    public Vector3 kretnja;       //  .
    public float trajanje;        // .
    public float zadnjePokazan;    //  .

    public void Show()
    {
        active = true;
        zadnjePokazan = Time.time;           // METODE SHOW I DOLJE NAVEDENI HIDE KORISTIMO DA NE DESTROYAM GAME OBJECT VEC GA MOGU UPORABIT VISE PUTA (RECIKLAZA, POOL mislim da to zovu)
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);             // NAPISAO SAM SI GORE VEC SVE
    }

    public void UpdateTxt()
    {
        if (!active)                     // Ako nije active vracaj se nemas sta tu radit vise
            return;

        if (Time.time - zadnjePokazan > trajanje)           // koristimo za micanje teksta u pravilno vrijeme, oduzmes vrijeme sa onom gore varijablom i ostatak zakljuci sam lagano je
            Hide();

        go.transform.position += kretnja * Time.deltaTime;    //Kad tekst ostane bude koristio vec3 da se pomakne malo najcesce prema gore iz mojih testova, nista znacajno al dobro za imat
    }
}
