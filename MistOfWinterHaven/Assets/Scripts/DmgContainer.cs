using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DmgContainer  // ok znaci struct je slican klasi, VELIKA RAZLIKA JE KLASA JE REFERENTNI TIP, NA NJU SE POZIVAMO, DOK JE STRUCT VRIJEDNOSNI TIP, bar sam tak zakljucio sam neznam
{
    public Vector3 origin;//Vector
    public int dmgAmmount;//Doslovno varijable koristene kasnije ovdje ih sam imam
    public float pushForce;//Isto kao gore
}
