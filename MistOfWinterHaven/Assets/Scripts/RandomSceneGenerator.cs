using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneGenerator : MonoBehaviour
{
    public static bool isEmpty = false;
    int index = 0;
    public List<string> s;
    public static RandomSceneGenerator instance;
    GameObject border;
    // Start is called before the first frame update
    void Start()
    {
        Scenes1();
        border = GameObject.Find("Border");
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

    // Update is called once per frame
    void Update()
    {
        if (isEmpty)
        {
            Scenes1();
            isEmpty = false;
        }
    }
    void Scenes1()
    {
        s.Add("Scena1");
        s.Add("Scena2");
        s.Add("Scena4");
        s.Add("Scena5");
        s.Add("Scena6");
        s.Add("Scena8");
        s.Add("Scena9");
        s.Add("Scena10");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        index = Random.Range(0, s.Count);
        SceneManager.LoadScene(s[index]);
        s.RemoveAt(index);
        if (s.Count == 4)
        {
            SceneManager.LoadScene("Scena7");
        }
        if (s.Count == 0)
        {
            SceneManager.LoadScene("Scena11");
        }
    }
}
