using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector2 moveDirection;
    [SerializeField] float speed;
    [SerializeField] bool isFacingRight;
    [SerializeField] bool isAttack;
    [SerializeField] Joystick _joyStick;
    public GameObject projectile;

    public List<GameObject> enemies;

    public List<GameObject> weapons;
    public bool isSword;
    public bool isDart;

    public Rigidbody2D rb;
    public Animator anim;

    float moveX;
    float moveY;

    public int currrentHealth;
    public int maxHealth = 100;

    public LoadingBar healthBar;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        ProcessInput();
        Flip();
        detectEnemies();
        Attack();
    }

    private void FixedUpdate()
    {
        StatePlayer();
    }

    void ProcessInput()
    {
        moveX = _joyStick.Horizontal;
        moveY = _joyStick.Vertical;
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void StatePlayer()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        if (moveDirection.x != 0f)
        {
            anim.Play("Run");
        }
        else if (moveDirection.x == 0f && !isAttack)
        {
            anim.Play("Idle");
        }
    }
    void Flip()
    {
        if (isFacingRight && moveX > 0f || !isFacingRight && moveX < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void Attack()
    {

        if (!isAttack)
        {
            isAttack = true;
            detectEnemies();
            StartCoroutine(checkAttack());
            if(isDetectEnemy)
            {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                Debug.Log(bullet);
                Debug.Log("NhuQuyen");

            }
        }
    }
    IEnumerator checkAttack()
    {
        yield return new WaitForSeconds(1);
        isAttack = false;
    }

    void TakeDamage(int damage)
    {
        currrentHealth -= damage;
        healthBar.SetHealth(currrentHealth);
        if (currrentHealth <= 0)
        {
            Debug.Log("PlayerDead");
        }
    }
    public float dis;
    public Vector2 enemyPos;
    public bool isDetectEnemy;
    void detectEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            dis = Vector2.Distance(transform.position, enemies[i].transform.position);
            if (dis < 4)
            {
                isDetectEnemy = true;
                enemyPos = enemies[i].transform.position;
            }
            else
            {
                isDetectEnemy = false;
                Debug.Log("Have no enemy here");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Blade"))
        {
            Destroy(col.gameObject);
            projectile = weapons[0];
            Debug.Log("Get blade");
        }

        if (col.gameObject.CompareTag("Brick"))
        {
            Destroy(col.gameObject);
            projectile = weapons[1];
            Debug.Log("Get blade");
        }

    }

}
