using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public Slider volumeSlider;
    public static bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
            isMuted = true;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
            isMuted = false;
        }
    }
}
