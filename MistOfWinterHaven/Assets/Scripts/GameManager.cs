using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject keyBinds;
    public GameObject gui;
    public GameObject pause;
    bool isInGame = false;
    bool isPause = false;
    public static GameManager instance;
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
        SceneManager.LoadScene("Game");
        mainMenu.SetActive(false);
        isInGame = true;
        gui.SetActive(true);
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
        isPause = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pause.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScreen");
        isInGame = false;
        mainMenu.SetActive(true);
        pause.SetActive(false);
        gui.SetActive(false);
    }
}
