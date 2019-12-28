using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Geracao : MonoBehaviour
{

    public GameObject morcego;
    public GameObject pedra;

    public bool alteronda = false;
    public float cooldownmorcego = 5f;
    public float posmax;
    public float posmin;
    public static float tempo = 0f;

    public static int pontuacao;
    public static int vidas = 3;

    public TextMeshProUGUI ponttxt;
    public TextMeshProUGUI tempotxt;
    public TextMeshProUGUI vidatxt;

    public int quantidade = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GerarMorcego());
        GerarPedra();
    }

    private void Update()
    {
        tempo = Time.time;
        Atualizartxts();
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

    IEnumerator GerarMorcego() {

        Instantiate(morcego);
        morcego.transform.position = new Vector2(Random.Range(posmin,posmax),6.5f);
        yield return new WaitForSeconds(cooldownmorcego);
        StartCoroutine(GerarMorcego());

    }
}
