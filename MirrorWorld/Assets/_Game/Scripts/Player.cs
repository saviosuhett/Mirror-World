using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject gameovertxt;
    public int maxHealth = 1000;
    public int currentHealth;

    public HealthBar healthBar;

    public int chavesColetadas = 0;

    public bool onFloor;
    public bool onCeiling;

    public bool darkSide;
    public bool whiteSide;

    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;


    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float maxSpeed = 0;

    [SerializeField]
    private float forceJump = 0;


    private Material material;
    int clickCount = 0;
    private bool gravity;

    public bool isNegative;
    void Start()
    {

        Time.timeScale = 1f;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Jump();
        // Move(); era speed 8 e max speed 8
        ActiveNegative();
        GravityController();
        Retry();


        print("Total de chaves: " + chavesColetadas);
        print("Clicks: " + clickCount);
    }

    void FixedUpdate()
    {
        Move();
        GameOver();
    }

    public void Move()
    {
        if (gravity == false)
        {
            float eixoX = Input.GetAxisRaw("Horizontal");
            Vector2 moveInputX = new Vector2(eixoX, 0);
            var velocity = rb2d.velocity;
            velocity += moveInputX * speed * Time.fixedDeltaTime;
            moveInputX = Vector2.zero;
            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = velocity;

            if (eixoX == 0.0)
            {
                rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);
                playerAnimator.SetBool("run", false);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0.0f)
            {
                playerAnimator.SetBool("run", true);
                spriteRenderer.flipX = false;

                print("is Move");

            }
            else if (Input.GetAxisRaw("Horizontal") < 0.0f)
            {
                playerAnimator.SetBool("run", true);
                spriteRenderer.flipX = true;

                print("is Move");
            }
        }
    }

    public void Jump()
    {
        if (onFloor && Input.GetKeyDown(KeyCode.Space))
        {
            onFloor = false;
            playerAnimator.SetBool("jump", true);
      
            rb2d.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            SoundManager.PlaySound("playerJump");
            print("Jump chao");

        }
        else if (onCeiling && Input.GetKeyDown(KeyCode.Space))
        {
            onCeiling = false;
            playerAnimator.SetBool("jump", true);

            rb2d.AddForce(Vector2.down * forceJump, ForceMode2D.Impulse);
            SoundManager.PlaySound("playerJump");
            print("Jump teto");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("chao"))
        {
            onFloor = true;
            onCeiling = false;

            gravity = false;

            playerAnimator.SetBool("jump", false);
            print("Chao: " + onFloor);
        }

        if (other.collider.CompareTag("teto"))
        {
            onCeiling = true;
            onFloor = false;

            gravity = false;

            playerAnimator.SetBool("jump", false);
            print("Teto: " + onCeiling);
        }

    }

    // aplicando o negative no player ao passar pra um dos lados
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("darkSide"))
        {
            material.SetFloat("_Negative", 1f);
            transform.localScale = new Vector2(1, -1);
            rb2d.gravityScale = -1;

            darkSide = true;
            whiteSide = false;
            print("Dark side");
        }
        if (other.CompareTag("whiteSide"))
        {
            material.SetFloat("_Negative", 0f);
            transform.localScale = new Vector2(1, 1);
            rb2d.gravityScale = 1;

            whiteSide = true;
            darkSide = false;
            print("White side");
        }
    }

    void ActiveNegative()
    {
        if (darkSide)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                material.SetFloat("_Negative", 0f);
                isNegative = true;
                print("Dark negative: " + isNegative);
            }
            else
            {
                material.SetFloat("_Negative", 1f);
                isNegative = false;
                print("Dark negative: " + isNegative);
            }
        }
        if (whiteSide)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                material.SetFloat("_Negative", 1f);
                isNegative = true;
                print("White negative: " + isNegative);
            }
            else
            {
                material.SetFloat("_Negative", 0f);
                isNegative = false;
            }
        }
    }

    void GravityController()
    {
        if (darkSide)
        {
            if (Input.GetMouseButtonDown(1))
            {
                gravity = true;
                clickCount++;
                if (clickCount == 1)
                {
                    rb2d.gravityScale = 1f;
                    transform.localScale = new Vector2(1, 1);
                }
                if (clickCount > 1)
                {
                    rb2d.gravityScale = -1f;
                    transform.localScale = new Vector2(1, -1);
                    clickCount = 0;
                }
            }
        }
        if (whiteSide)
        {
            if (Input.GetMouseButtonDown(1))
            {
                gravity = true;
                clickCount++;
                if (clickCount == 1)
                {
                    rb2d.gravityScale = -1f;
                    transform.localScale = new Vector2(1, -1);
                }
                if (clickCount > 1)
                {
                    rb2d.gravityScale = 1f;
                    transform.localScale = new Vector2(1, 1);
                    clickCount = 0;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void IncrementoDano()
    {
        currentHealth += 50;
        healthBar.SetHealth(currentHealth);
    }


    void GameOver()
    {
        if (currentHealth <= 0)
        {

            Time.timeScale = 0f;
            Debug.Log("Game Over");
            gameovertxt.SetActive(true);
        }
    }
    void Retry()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.timeScale == 0)
        {
            SceneManager.LoadScene("Level Design");
        }
    }
}
