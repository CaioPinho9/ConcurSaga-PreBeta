using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Jogo : MonoBehaviour
{
    public List<Pergunta> database = new();
    public GameObject tela;
    public GameObject restart;
    public GameObject gameOverScreen;
    public float time;
    public float maxTime;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 15;
        time = 15;
        database = Pergunta.Database();
        Change();
    }

    void Update()
    {
        if (!gameOver)
        {
            time -= Time.deltaTime;
            GameObject.Find("Timer").GetComponent<Image>().fillAmount = time / maxTime;
            if (time <= 0)
            {
                time = 0;
                gameOver = true;
                restart.SetActive(true);
                gameOverScreen.SetActive(true);
            }
        }
    }

    public void Change()
    {
        Pergunta pergunta = database[Random.Range(0, database.Count)];
        GameObject.Find("Pergunta").GetComponent<Text>().text = pergunta.pergunta;
        GameObject.Find("Resposta1").GetComponentInChildren<Text>().text = pergunta.resposta1;
        GameObject.Find("Resposta2").GetComponentInChildren<Text>().text = pergunta.resposta2;
        GameObject.Find("Resposta3").GetComponentInChildren<Text>().text = pergunta.resposta3;
        GameObject.Find("Resposta4").GetComponentInChildren<Text>().text = pergunta.resposta4;

        Botao.certo = pergunta.certa;
    }
}

public class Pergunta
{
    public string pergunta;
    public string resposta1;
    public string resposta2;
    public string resposta3;
    public string resposta4;
    public int certa;

    public Pergunta(string pergunta, string resposta1, string resposta2, string resposta3, string resposta4, int certa)
    {
        this.pergunta = pergunta;
        this.resposta1 = resposta1;
        this.resposta2 = resposta2;
        this.resposta3 = resposta3;
        this.resposta4 = resposta4;
        this.certa = certa;
    }

    public static List<Pergunta> Database()
    {
        List<Pergunta> database = new()
        {
            new("24 (mod 7) é igual a", "2", "3", "24", "4", 2),
            new("Garrido não falou:", "judeu safado", "porta aberta", "astrologia", "meu aluno morreu", 3),
            new("Garrido tem aula quantas vezes no semestre:", "uma vez", "duas vezes", "tres vezes", "quatro vezes", 1),
            new("U - A resulta no(a)", "identidade", "transposta", "complementar", "fecho simétrico", 3),
            new("A transição entre a primeira e segunda geração de computadores é marcada pelo surgimento do(a)", "microprocessador", "transistor", "válcula", "circuito integrado", 2)
        };
        return database;
    }
}
