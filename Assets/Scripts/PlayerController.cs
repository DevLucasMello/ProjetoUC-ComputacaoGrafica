using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private float verticalInput;
    private float horizontalInput;
    public int qtdVidas;

    static public bool venceu;

    void Start()
    {
        qtdVidas = 10;
        venceu = false;
    }
    // Update is called once per frame
    void Update()
    {
        Menu.qtdVida = qtdVidas;
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0) {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 0.4f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Time.timeScale = 1.0f;
        }

    }

    

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag != "indestrutivel")
        {
            if (collision.transform.tag == "Obstaculo")
            {
                if (qtdVidas >= 0)
                {
                    qtdVidas = Menu.qtdVida - 1;

                }
                else
                {
                    Destroy(collision.transform.gameObject);
                    Destroy(gameObject);
                }
            }
        }

        if (collision.transform.tag == "Vida")
        {
            if (qtdVidas < 10)
            {
                qtdVidas = Menu.qtdVida + 1;
                Destroy(collision.transform.gameObject);
            }
            else {

                Destroy(collision.transform.gameObject);
            }
        }

        if (collision.transform.tag == "Final")
        {
            venceu = true;
        }
    }


}
