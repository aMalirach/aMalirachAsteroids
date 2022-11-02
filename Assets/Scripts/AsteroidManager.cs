using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Gestion multiply asteroids 
    // Spawnear y colocar (X) asteroides en pantalla 

    public GameObject insAsteroid;

    public int asteroidsMin = 2;
    public int asteroidsMax = 4;

    public int AsteroidOnStage; 

    public float limitX = 10;
    public float limitY = 6; 

    void Start()
    {
        CreationAsteroids(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(AsteroidOnStage <= 0)
        {

            GameManager.instance.round += 1; 

            if (GameManager.instance.round > 1 && GameManager.instance.round % GameManager.instance.bonusRound == 0)
                GameManager.instance.lives += GameManager.instance.bonusLives; 

            asteroidsMax += 2;
            asteroidsMin += 2; 

            CreationAsteroids();
        }
            
        
    }

    void CreationAsteroids()
    {
        int asteroids = Random.Range(asteroidsMin, asteroidsMax);

        for (int i = 0; i < asteroids; i++)
        {

            Vector3 position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while(Vector3.Distance(position, new Vector3(0, 0)) < 2)
            {
                position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));

            GameObject tem = Instantiate(insAsteroid, position, Quaternion.Euler(rotation));
            tem.GetComponent<AsteroidControler>().managerAsteroid = this;

        }

    }

}
