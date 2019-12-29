using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canhao : MonoBehaviour
{

    public float firerate = 2f;
    public float firecooldown = 0;

    public static int tipotiro = 0;
    public int forca = 250;
    public int velocidadeeixo = 500;

    public HingeJoint2D Eixo;

    public GameObject bala;
    public GameObject localdotiro;

    // Start is called before the first frame update
    void Start()
    {
        tipotiro = 0;
        Eixo = GetComponent<HingeJoint2D>();
        StartCoroutine(Rotacao());
    }

    // Update is called once per frame
    void Update()
    {
        Controle();
        Rotacao();
    }

    public void Controle() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!GameManager.GameOver)
            {
                Atirar();
            }
            else
            {
                SceneManager.LoadScene("Jogo");
            }
        }
    }

    public void Atirar()
    {
        if (GameManager.tempo > firecooldown)
        {
            if (tipotiro == 0)
            {
                var balapref = Instantiate(bala, localdotiro.transform);
                balapref.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * forca);
                firecooldown = GameManager.tempo + firerate;
            }
            if (tipotiro == 1)
            {
                var balapref = Instantiate(bala, localdotiro.transform);
                balapref.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * forca);
                firecooldown = GameManager.tempo + (firerate/2);
            }
            if (tipotiro == 2 || tipotiro == 3)
            {
                for (int i = 0; i < tipotiro; i++)
                {
                    var balapref = Instantiate(bala, localdotiro.transform);
                    balapref.transform.position = new Vector2(balapref.transform.position.x + i,balapref.transform.position.y);
                    balapref.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * forca);
                    firecooldown = GameManager.tempo + firerate;
                }             
            }
            if (tipotiro == 4)
            {
                for (int i = 1; i < 5; i++)
                {
                    var balapref = Instantiate(bala, localdotiro.transform);
                    balapref.transform.position = new Vector2(balapref.transform.position.x, balapref.transform.position.y - (i*0.20f));
                    balapref.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * forca);
                    firecooldown = GameManager.tempo + firerate;
                }
            }
        }
    }

    IEnumerator Rotacao() {

        JointMotor2D m = Eixo.motor;
        m.motorSpeed = -velocidadeeixo;
        Eixo.motor = m;
        yield return new WaitForSeconds(1.5f);
        m.motorSpeed = velocidadeeixo;
        Eixo.motor = m;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Rotacao());

    }
}
