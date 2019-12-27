using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{

    public float firerate = 2f;
    public float tempo = 0f;

    public int forca = 250;
    public int velocidadeeixo = 500;

    public HingeJoint2D Eixo;

    public GameObject bala;
    public GameObject localdotiro;

    // Start is called before the first frame update
    void Start()
    {
        tempo = Time.time;
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
            Atirar();
        }
    }

    public void Atirar()
    {
        var balapref = Instantiate(bala, localdotiro.transform);
        balapref.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * forca);
    }

    IEnumerator Rotacao() {
        JointMotor2D m = Eixo.motor;
        m.motorSpeed = -velocidadeeixo;
        Eixo.motor = m;
        yield return new WaitForSeconds(1.4f);
        m.motorSpeed = velocidadeeixo;
        Eixo.motor = m;
        yield return new WaitForSeconds(1.4f);
        StartCoroutine(Rotacao());

    }
}
