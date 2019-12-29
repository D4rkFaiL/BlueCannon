using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : MonoBehaviour
{
    public int vida;
    public int valordepontuacao = 100;
    public int velocidademov = 250;

    public List<Color> Cores = new List<Color>();

    public Rigidbody2D rb;
    private void Start()
    {
        vida = GameManager.dificuldade;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * velocidademov);

        var SpriteRend = GetComponent<SpriteRenderer>();
        SpriteRend.color = Cores[vida];
    }
    // Update is called once per frame
    void Update()
    {
        VerificarMorte();
        Movimentar();
    }

    void Movimentar()
    {
        if (transform.position.x > -7)
        {
            rb.AddForce(Vector2.left * velocidademov);
        }

        if (transform.position.x < 6)
        {
            rb.AddForce(Vector2.right * velocidademov);
        }
    }
    void VerificarMorte()
    {
        if (transform.position.y < -7)
        {
            GameManager.vidas -= 1;
            Destroy(this.gameObject);
        }
    }

    //public void Destruir()
    //{
    //    Destroy(this.gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bala"))
        {
            GameManager.pontuacao += valordepontuacao;
            //Destruir();
        }
    }
}
