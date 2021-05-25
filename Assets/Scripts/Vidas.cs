using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour

{
 
    public int Recarregavidas, rotacao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotacao * Time.deltaTime, 0);
   
    }

    public void OnCollisionEnter(Collision collision) {

        PlayerController carro = collision.transform.GetComponent<PlayerController>();

        if (collision.transform.tag != "indestrutivel") {
            if (collision.transform.tag == "Player") {
                Destroy(gameObject);
                carro.qtdVidas += Recarregavidas;
            }
        }
    }

}
