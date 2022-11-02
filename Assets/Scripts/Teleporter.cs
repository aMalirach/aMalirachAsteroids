using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public float limitX = 10;
    public float limitY = 6;


    void Start()
    {
        
    }

    
    void Update()
    {

        // pass limit Y (back scene counter value)

        if (transform.position.y > limitY)
            transform.position = new Vector3(transform.position.x, -limitY);

        if (transform.position.y < -limitY)
            transform.position = new Vector3(transform.position.x, limitY);

        // pass limit X (back scene counter value)

        if (transform.position.x > limitX)
            transform.position = new Vector3(-limitX, transform.position.y);

        if (transform.position.x < -limitX)
            transform.position = new Vector3(limitX, transform.position.y);


    }
}
