using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{

    public AsteroidManager managerAsteroid; 

    // Gestion individual asteriod  
    Rigidbody2D rb;

    public float speedMin = 100;
    public float speedMax = 200; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        direction *= Random.Range(speedMin,speedMax);

        rb.AddForce(direction);

        managerAsteroid.AsteroidOnStage += 1; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {

        if(transform.localScale.x > 0.25f)
        {

            GameObject tem1 = Instantiate(managerAsteroid.insAsteroid, transform.position, transform.rotation);
            tem1.GetComponent<AsteroidControler>().managerAsteroid = managerAsteroid;
            tem1.transform.localScale = transform.localScale * 0.5f;

            GameObject tem2 = Instantiate(managerAsteroid.insAsteroid, transform.position, transform.rotation);
            tem2.GetComponent<AsteroidControler>().managerAsteroid = managerAsteroid;
            tem2.transform.localScale = transform.localScale * 0.5f;

        }

        GameManager.instance.puntuation += 100;
        managerAsteroid.AsteroidOnStage -= 1; 

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().Dead();
        }

    }

}
