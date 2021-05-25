using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour    
{
    public float VelRot;

    public GameObject[] locais;
    public int destinoInicial = 0;
    public float velocidade = 0;
    public bool comecarInvertido;
    public bool reiniciarSequencia;

    int localAtual = 0;
    bool inverter = false;
    public int TiraVidas;
   

    // Start is called before the first frame update
    void Start()
    {
        if (destinoInicial < locais.Length)
        {
            localAtual = destinoInicial;
        }
        else
        {
            localAtual = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, VelRot * Time.deltaTime, 0);

        if (inverter == false)
        {
            if (Vector3.Distance(transform.position, locais[localAtual].transform.position) < 0.1f)
            {
                if (localAtual < locais.Length - 1)
                {
                    localAtual++;
                }
                else
                {
                    if (reiniciarSequencia == true)
                    {
                        localAtual = 0;
                    }
                    else
                    {
                        inverter = true;
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, locais[localAtual].transform.position, velocidade * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(transform.position, locais[localAtual].transform.position) < 0.1f)
            {
                if (localAtual > 0)
                {
                    localAtual--;
                }
                else
                {
                    if (reiniciarSequencia == true)
                    {
                        localAtual = locais.Length - 1;
                    }
                    else
                    {
                        inverter = false;
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, locais[localAtual].transform.position, velocidade * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag != "indestrutivel"){

            PlayerController carro = collision.transform.GetComponent<PlayerController>();
            
            if (carro.qtdVidas > 0)
            {
                
                carro.qtdVidas--;
                
            }
            else
            {
                Destroy(collision.transform.gameObject);
                Destroy(gameObject);
            }

        }
    }
}

