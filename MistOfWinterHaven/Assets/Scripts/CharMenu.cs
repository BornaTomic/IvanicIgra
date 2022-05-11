using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMenu : MonoBehaviour
{
    public Text levelText, hitpointText, coinsText, upgradeCostText, xpText;  //raznorazni textovi potrebni
    public Image weaponSprite; //isto img
    public void OnUpgradeClick()//koristimo za upgradeanje
    {
    }
    public void UpdateMenu()//Omogucuje mjenjanje informacija o podatcima playera preko GameManagera
    {
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];//uzimanje spritea za weapon

        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)//ako je doslo do zadnjeg oruzija i nije moguce upgradeat vise
        {
            upgradeCostText.text = "max";//samo napisemo max
        }
        else
        {
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();//ispis cijene za upgrade weapona
        }
    }
}
