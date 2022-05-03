using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootMagic : MonoBehaviour
{
    public static float damage;
    public Slider slider;
    public GameObject bullett;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            damage = slider.value;
            slider.value = 0;
            Instantiate(bullett, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Debug.Log(damage);
        }
    }
}
