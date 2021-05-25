using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private float verticalInput;
    private float horizontalInput;

    //public GameObject vidas;
    public int qtdVidas;
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0) {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            Time.timeScale = 0.4f;
        }
        /*
        else
        {
            Time.timeScale = 1;
        }*/
    }



}
