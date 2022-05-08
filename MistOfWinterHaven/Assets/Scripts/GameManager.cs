using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject keyBinds;
    public float MaxHealth;
    public float CurrentHEalth;
    public GameObject pause;
    public GameObject inventory;
    public GameObject gui;
    bool isInGame = false;
    bool isPause = false;
    public static GameManager instance;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    public Weapon weapon;
    public TxtManager txtmanager;
    public Player player;
    public int coins;
    public int exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && isInGame)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause && isInGame)
        {
            Resume();
        }

        if (CurrentHEalth >= MaxHealth) CurrentHEalth = MaxHealth;
    }

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("1.Level");
        mainMenu.SetActive(false);
        gui.SetActive(true);
        inventory.SetActive(true);
        isInGame = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        mainMenu.SetActive(false);
        pause.SetActive(false);
        settings.SetActive(true);
    }
    public void KeyBindsButton()
    {
        settings.SetActive(false);
        keyBinds.SetActive(true);
    }
    public void Back()
    {
        if (!isInGame)
        {
            mainMenu.SetActive(true);
            settings.SetActive(false);
            keyBinds.SetActive(false);
        }
        else
        {
            pause.SetActive(true);
            settings.SetActive(false);
            keyBinds.SetActive(false);
        }
    }

    public void Pause()
    {
        pause.SetActive(true);
        inventory.SetActive(false);
        isPause = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pause.SetActive(false);
        inventory.SetActive(true);
        isPause = false;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScreen");
        isInGame = false;
        mainMenu.SetActive(true);
        gui.SetActive(false);
        inventory.SetActive(false);
        pause.SetActive(false);
        RandomSceneGenerator.isEmpty = true;
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 kretnja, float trajanje) // E OVO TU TI JE ZNACI DA POZIVAS SAM FLOATING TEXT, NEZNAM ZAS SAM NASRO TO TU AL ONO NEMOJ SE ZBUNIT KAD KASNIJE CITAS
    {
        txtmanager.Show(msg, fontSize, color, position, kretnja, trajanje);
    }

    public bool TryUpgradeWeapon()
    {
        if (weaponPrices.Count <= weapon.weaponLevel)//Provjeravamo da oruzije nije slucajno vec max lvl
        {
            return false;
        }
        if (coins >= weaponPrices[weapon.weaponLevel])
        {
            coins -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }
}
