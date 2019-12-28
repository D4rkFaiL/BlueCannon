using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : MonoBehaviour
{
    public int vida = 1;
    public int valordepontuacao = 100;
    public int velocidademov = 250;

    public List<Color> Cores = new List<Color>();

    public Rigidbody2D rb;
    private void Start()
    {
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
            Geracao.vidas -= 1;
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bala"))
        {
            Geracao.pontuacao += valordepontuacao;
            Destruir();
        }
    }
}
