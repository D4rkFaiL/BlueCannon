using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Untagged"))
        {
            if (collision.CompareTag("PUDouble"))
            {
                Canhao.tipotiro = 2;
            }
            if (collision.CompareTag("PUMaior"))
            {
                Canhao.tipotiro = 4;
            }
            if (collision.CompareTag("PURapid"))
            {
                Canhao.tipotiro = 1;
            }
            if (collision.CompareTag("PUTriple"))
            {
                Canhao.tipotiro = 3;
            }
            Destroy(collision.gameObject);
        }
       
        Destroy(this.gameObject);

    }
}
