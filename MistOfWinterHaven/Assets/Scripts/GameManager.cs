using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject keyBinds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void KeyBindsButton()
    {
        settings.SetActive(false);
        keyBinds.SetActive(true);
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        keyBinds.SetActive(false);
    }
}
