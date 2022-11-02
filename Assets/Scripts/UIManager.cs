using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI lives;
    public TextMeshProUGUI time;
    public TextMeshProUGUI puntuation;
    public GameObject gameOver; 

    void Start()
    {
        
    }

    
    void Update()
    {

        if (GameManager.instance.lives != 0)
            time.text = Time.time.ToString("00.00");
        else gameOver.SetActive(true);

        puntuation.text = GameManager.instance.puntuation.ToString();

        lives.text = GameManager.instance.lives.ToString();


    }
}
