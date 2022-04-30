using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindsManager : MonoBehaviour
{
    public static Dictionary<string, KeyCode> dictionary = new Dictionary<string, KeyCode>();
    public Text up, down, right, left;
    GameObject CurrentKey;
    Color32 NormalColor = new Color32(255, 255, 255, 255);
    Color32 SelectedColor = new Color32(239, 116, 36, 255);
    // Start is called before the first frame update
    void Start()
    {
        dictionary.Add("MoveUp", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveUp", "W")));
        dictionary.Add("MoveDown", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveDown", "S")));
        dictionary.Add("MoveRight", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRight", "D")));
        dictionary.Add("MoveLeft", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeft", "A")));

        up.text = dictionary["MoveUp"].ToString();
        down.text = dictionary["MoveDown"].ToString();
        right.text = dictionary["MoveRight"].ToString();
        left.text = dictionary["MoveLeft"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        if (CurrentKey != null)
        {
            CurrentKey.GetComponent<Image>().color = SelectedColor;
            Event e = Event.current;
            if (e.isKey)
            {
                dictionary[CurrentKey.name] = e.keyCode;
                CurrentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                CurrentKey.GetComponent<Image>().color = NormalColor;
                CurrentKey = null;
            }
        }
    }

    public void SaveButton()
    {
        foreach (var item in dictionary)
        {
            PlayerPrefs.SetString(item.Key, item.Value.ToString());
        }
        PlayerPrefs.Save();
    }


    public void GetKey(GameObject clicked)
    {
        if (CurrentKey != null)
        {
            CurrentKey.GetComponent<Image>().color = NormalColor;
        }

        this.CurrentKey = clicked;
    }
}
