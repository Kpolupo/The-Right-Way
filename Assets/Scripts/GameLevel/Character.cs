using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    public static Character characterInstance;

    private float moveSpeed = 0.1f; 
    float xInput, yInput; //genero dos valores de movimiento
    Vector2 targetPos;
    SpriteRenderer sp;
    Rigidbody2D rb;
    private float maxHP = 100;
    private float HP;
    public float addScore;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchPoint;
    public HealthBar healthBar;
    public float finalScore;



    private void Awake()
    {
        characterInstance = this;
        finalScore = 0;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true; //para evitar que al colisionar, comience a rotar
        Debug.Log("final score = " + finalScore);
        HP = maxHP;
        healthBar.setMaxHealth(maxHP);
    }


    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }


    void FlipEntity() //rotar el personaje izq o derecha
    {
        if(rb.velocity.x < -0.01f)
        {
            sp.flipX = true;
            
        }
        else if(rb.velocity.x > 0.01f)
        {
            sp.flipX = false;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        Debug.Log("HP Jugador = " + HP);
        healthBar.SetHealth(HP);
    }


    private void Update()
    {
         if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, LaunchPoint.position, LaunchPoint.rotation);
        }
        if (HP <= 0)
        {
            Destroy(gameObject); //CAMBIAR PANTALLA A GAME OVER
            SceneManager.LoadScene(2);

        }

    }


    private void FixedUpdate() //vinculo los valores de movimiento con inputs del teclado
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0); //para que pueda moverse dentro de los ejes xAxys y yAxys, zAxys es 0 para que no se mueva en ese eje

        PlatformerMove();
        FlipEntity();

    }
}
