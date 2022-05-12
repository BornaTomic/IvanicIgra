using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject gameManager;
    Renderer rend;
    public float speed = 0f;
    public float fireRate = 0f;
    bool canShoot = true;
    bool isSnake = false;
    public static bool isDead = false;
    public static bool isDamaged = false;
    public static POV pov = POV.desno;
    Animator animator;
    public static float damage;
    Slider slider;
    public GameObject bullett;
    Player instance;
    public Material Defuser;
    public Material Defult;
    bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        animator = GetComponent<Animator>();
        slider = GameObject.Find("MagicSlider").GetComponent<Slider>();
        rend = GetComponent<Renderer>();
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
        if (isSnake && canAttack)
        {
            StartCoroutine(SnakeDamage());
        }
        if (isDead)
        {
            animator.SetInteger("Anim", 3);
            Destroy(gameObject);
            isDead = false;
        }
        if (Input.GetKey(KeyBindsManager.dictionary["MoveUp"]) && !isDead)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            pov = POV.gore;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveDown"]) && !isDead)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            pov = POV.dolje;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveLeft"]) && !isDead)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            pov = POV.lijevo;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveRight"]) && !isDead)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            pov = POV.desno;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetInteger("Anim", 0);
        }
        if (Input.GetKeyDown(KeyCode.F) && canShoot && !isDead)
        {
            damage = slider.value;
            slider.value = 0;
            var obj = Instantiate(bullett, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            obj.GetComponent<Bullett>().povB = pov;
            StartCoroutine(FireRate());
        }

        if(SceneManager.GetActiveScene().name == "PrviLvl" || SceneManager.GetActiveScene().name == "Zadnja NPC scena")
        {
            rend.material = Defult;
        }
        else
        {
            rend.material = Defuser;
        }

        if (isDamaged && !isDead)
        {
            animator.SetInteger("Anim", 2);
            isDamaged = false;
        }
    }
    IEnumerator SnakeDamage()
    {
        gameManager.GetComponent<GameManager>().CurrentHEalth -= 30;
        isSnake = false;
        canAttack = false;
        Player.isDamaged = true;
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }
    IEnumerator FireRate()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            isSnake = true;
        }
    }
}

public enum POV
{
    gore,
    dolje,
    desno,
    lijevo
}
