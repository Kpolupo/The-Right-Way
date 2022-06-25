using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    private float HP = 12;
    private float damage = 10;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
        moveSpeed = 2f;
        localScale = transform.localScale;
        rb.freezeRotation = true;
    }


    private void Update()
    {
        MoveEnemy();
        CheckDeath();
    }


    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }


    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }


    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount; 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void CheckDeath()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            Character.characterInstance.finalScore += Character.characterInstance.addScore;
            Debug.Log("addscore = " + Character.characterInstance.addScore + " finalscore = " + Character.characterInstance.finalScore); //debug para ver si anda
        }
    }
}