using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public static int isMuted = 0;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muteVolume"))
        {
            PlayerPrefs.SetFloat("muteVolume", 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute(bool muted)
    {
        if (muted && isMuted == 0)
        {
            AudioListener.volume = 0;
            isMuted = 1;
            Save();
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
            isMuted = 0;
            Save();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("muteVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muteVolume", isMuted);
    }
}
