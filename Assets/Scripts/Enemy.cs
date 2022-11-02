using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D collider;

    public GameObject enemy; 

    public float velocity = 100f;

    float contador;

    float positionX, positionY; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();

    }

    
    void Update()
    {
        
        if(GameManager.instance.puntuation >= 1000)
        {
            contador += 1;
        }

        if(contador == 60)
        {

            Vector3 pos = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6));

            GameObject temp = Instantiate(enemy, pos, Quaternion.identity);



            contador = 0; 
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            GameManager.instance.puntuation += 1000; 
        }

    }

}
