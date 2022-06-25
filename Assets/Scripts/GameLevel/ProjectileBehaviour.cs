using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float Speed = 10.1f;
    private Rigidbody m_Rigidbody;
    private int damage = 3;


    
    void Awake()
    {

    }


    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemies>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}