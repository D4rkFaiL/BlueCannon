using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> PowerUps = new List<GameObject>();
    public GameObject morcego;
    public GameObject pedra;
    public GameObject GameOverGO;

    public bool alteronda = false;
    public static bool GameOver = false;

    public float cooldownmorcego = 5f;
    public float posmax;
    public float posmin;
    public static float tempo = 0f;

    public int cooldownpowerup = 15;
    public static int dificuldade = 1;
    public static int pontuacao;
    public static int vidas = 3;

    public TextMeshProUGUI ponttxt;
    public TextMeshProUGUI tempotxt;
    public TextMeshProUGUI vidatxt;
    public TextMeshProUGUI gameovertxt;

    public int quantidade = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        dificuldade = 1;
        pontuacao = 0;
        vidas = 3;
        tempo = 0;
        
        StartCoroutine(GerarMorcego());
        StartCoroutine(GerarPowerUps());
        GerarPedra();
    }

    private void Update()
    {
        tempo = Time.timeSinceLevelLoad;
        Atualizartxts();
        GerenciarDificuldade();

        if (vidas <= 0)
        {
            GameOverVeri();
        }
    }

    void GameOverVeri()
    {
        GameOver = true;
        GameOverGO.SetActive(true);
        gameovertxt.text = "Fim de Jogo\nPontuacão Final:\n" + pontuacao + "\nClique para reiniciar";
    }

    void GerenciarDificuldade()
    {
        if (Mathf.RoundToInt(tempo) > 100 * dificuldade && dificuldade <= 3)
        {
            dificuldade += 1;
        }
    }

    void Atualizartxts()
    {
        string minSec = string.Format("{0}:{1:00}", (int)tempo / 60, (int)tempo % 60);
        tempotxt.text = "Tempo: " + minSec;
        ponttxt.text = "Pontuação: " + pontuacao;
        vidatxt.text = "Vidas: " + vidas;
    }

    void GerarPedra() {
        for (int i = 0; i < quantidade; i++)
        {
            var pedrapref = Instantiate(pedra);
            pedrapref.transform.position = new Vector2(Random.Range(-7.2f, 4.7f), Random.Range(-0.2f, 5.7f));
        }
    }

    IEnumerator GerarPowerUps()
    {
        yield return new WaitForSeconds(cooldownpowerup + Random.Range(0,10));
        var PowerUpInsta = Instantiate(PowerUps[Random.Range(0,3)]);
        PowerUpInsta.transform.position = new Vector2(Random.Range(posmin, posmax), 6.5f);
        StartCoroutine(GerarPowerUps());
    }

    IEnumerator GerarMorcego() {
        Instantiate(morcego);
        morcego.transform.position = new Vector2(Random.Range(posmin,posmax),6.5f);
        yield return new WaitForSeconds(cooldownmorcego - dificuldade);
        StartCoroutine(GerarMorcego());
    }
}
