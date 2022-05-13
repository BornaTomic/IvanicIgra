using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject keyBinds;
    public GameObject youDied;
    GameObject doorTrigger;
    public float MaxHealth;
    public float CurrentHEalth;
    public GameObject pause;
    public GameObject inventory;
    public GameObject gui;
    public static bool isInGame = false;
    bool isPause = false;
    public static GameManager instance;
    public Player player;
    GameObject player1;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHEalth > MaxHealth)
        {
            CurrentHEalth = MaxHealth;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && isInGame)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause && isInGame)
        {
            Resume();
        }

        if (CurrentHEalth <= 0)
        {
            StartCoroutine(YouDied());
            CurrentHEalth = 200;
        }
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
        Snake.snakeLenght = 0;
        CurrentHEalth = 200;
        SceneManager.LoadScene("PrviLvl");
        mainMenu.SetActive(false);
        gui.SetActive(true);
        inventory.SetActive(true);
        Destroy(GameObject.Find("Sword Button(Clone)"));
        Destroy(GameObject.Find("Border(Clone)"));
        Destroy(GameObject.Find("Health Button 100(Clone)"));
        Destroy(GameObject.Find("Health Button 100(Clone)"));
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
        Destroy(player1);
        Player.isDead = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScreen");
        isInGame = false;
        mainMenu.SetActive(true);
        gui.SetActive(false);
        inventory.SetActive(false);
        pause.SetActive(false);
        doorTrigger = GameObject.Find("DoorTrigger");
        doorTrigger.GetComponent<RandomSceneGenerator>().s.Clear();
        RandomSceneGenerator.isEmpty = true;
    }
    IEnumerator YouDied()
    {
        youDied.SetActive(true);
        yield return new WaitForSeconds(5f);
        MainMenu();
        youDied.SetActive(false);
    }
}
