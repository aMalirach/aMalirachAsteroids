using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer spr; 

    public GameObject insBuller;
    public GameObject canonShip;
    public GameObject explotion; 

    public float speed = 100;
    public float rotationSpeed = -200;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");

        if(vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true); 
        }
        else anim.SetBool("Impulsing", false);


        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);
        
        if(Input.GetButtonDown("Jump") && collider.enabled == true) // desactived shoot
        {
            GameObject temp = Instantiate(insBuller, canonShip.transform.position, transform.rotation);
            Destroy(temp, 2f); 
        }

    }

    public void Dead()
    {

        collider.enabled = false;
        spr.enabled = false; 

        GameObject tem = Instantiate(explotion, transform.position, transform.rotation);
        Destroy(tem, 3f);

        GameManager.instance.lives -= 1;

        if (GameManager.instance.lives <= 0)
            Destroy(gameObject);
        else StartCoroutine(RespawnCoroutine());


    }

    IEnumerator RespawnCoroutine()
    {

        collider.enabled = false;
        spr.enabled = false;

        yield return new WaitForSeconds(2.5f);

        collider.enabled = true;
        spr.enabled = true;

        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);

    }

}
