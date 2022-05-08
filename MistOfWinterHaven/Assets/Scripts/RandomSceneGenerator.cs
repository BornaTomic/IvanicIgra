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
    // Start is called before the first frame update
    void Start()
    {
        Scenes1();
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
        s.Add("Scene1");
        s.Add("Scene2");
        s.Add("Scene3");
        s.Add("Scene4");
        s.Add("Scene5");
        s.Add("Scene6");
        s.Add("Scene7");
        s.Add("Scene8");
        s.Add("Scene9");
        s.Add("Scene10");
        s.Add("Scene11");
        s.Add("Scene12");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        index = Random.Range(0, s.Count);
        SceneManager.LoadScene(s[index]);
        s.RemoveAt(index);
        if (s.Count == 0)
        {
            SceneManager.LoadScene("Snake level");
        }
    }
}
