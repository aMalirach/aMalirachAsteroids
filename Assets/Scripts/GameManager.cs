using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int lives = 3;
    public int puntuation = 0;

    public int bonusLives = 3;
    public int bonusRound = 2;

    public int bonus = 1;
    public int bonusPuntuation = 1000; 

    public int round = 0; 

    private void Awake()
    {
        instance = this; 
    }


}
