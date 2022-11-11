using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botao : MonoBehaviour
{
    public static int certo;
    public int id;
    private Jogo jogo;
    // Start is called before the first frame update
    void Start()
    {
        jogo = GameObject.Find("Game").GetComponent<Jogo>();
    }

    public void Apertar()
    {
        if (!jogo.gameOver)
        {
            if (id == certo)
            {
                gameObject.GetComponent<Image>().color = Color.green;
                jogo.time += 2;
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.red;
            }
            if (jogo.time > 15)
            {
                jogo.time = 15;
            }
            Invoke(nameof(Change), 1);
        }
    }

    void Change()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        jogo.Change();
    }

    public void Restart()
    {
        jogo.gameOver = false;
        GameObject.Find("Restart").SetActive(false);
        GameObject.Find("GameOver").SetActive(false);
        jogo.time = jogo.maxTime;
    }
}
