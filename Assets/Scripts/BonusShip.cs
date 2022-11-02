using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShip : MonoBehaviour
{

    public GameObject insBoShip;

    Rigidbody2D rb;
    CircleCollider2D collider; 

    public float velocity = 50f;
    float positionX, positionY;

    bool shipDestroy = false; 

    public int randomNum; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    
    void Update()
    {
        
        if(GameManager.instance.round % 5 == 0) // cada 5 niveles, a aparece (5,10,15....)
        {

            // random number decides initial position bonusShip
            randomNum = Random.Range(1, 10 + 1);

            if(randomNum % 2 == 0) // Si número es par, eje X movimiento
            {

                if(randomNum < 5) // 6,8,10: 10X a -10X
                {
                    transform.position = new Vector3(positionX, positionY, randomNum);
                    positionX = -10;
                    positionY = 0; 
                }
                else if(randomNum >5) // 2,4 : -10x a 10X
                {
                    positionX = 10;
                    positionY = 0;
                }

            }
            else // Si número impar, eje Y movimiento
            {
                if (randomNum <= 5) // 1,3,5 : -6Y a 6Y
                {
                    positionX = 0;
                    positionY = -6;
                }
                else if (randomNum > 5) // 7,9: 6Y a -6Y
                {
                    positionX = 0;
                    positionY = 6;
                }
            }

        }

        if(randomNum % 2 == 0 && randomNum < 5)
        {
            // GameObject tem = Instantiate(insAsteroid, position, Quaternion.Euler(rotation));
            if (positionX < 11 || shipDestroy != true)
            {
                GameObject tem = Instantiate(insBoShip); 
                Vector3 move = new Vector3(positionX * velocity * Time.deltaTime, positionY);
                transform.position += move;
            }
            else Destroy(rb); 

        }
        else if(randomNum % 2 == 0 && randomNum > 5)
        {

            if (positionX > -11 || shipDestroy != true)
            {
                Vector3 move = new Vector3(positionX * velocity * Time.deltaTime, positionY);
                transform.position += move;
            }
            else Destroy(rb);

        }
        else if (randomNum % 2 != 0 && randomNum < 5)
        {
            if (positionX < 7 || shipDestroy != true)
            {
                Vector3 move = new Vector3(positionX, positionY * velocity * Time.deltaTime);
                transform.position += move;
            }
            else Destroy(rb);
        }
        else
        {
            if (positionX > -11 || shipDestroy != true)
            {
                Vector3 move = new Vector3(positionX, positionY * velocity * Time.deltaTime);
                transform.position += move;
            }
            else Destroy(rb);
        }

    }
}
