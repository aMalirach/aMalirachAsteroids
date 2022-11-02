using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed = 300f; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * speed); 

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidControler>().Dead();
            Destroy(gameObject); 
        }

    }

}
