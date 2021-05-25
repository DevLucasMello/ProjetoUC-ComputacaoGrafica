using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configGeral : MonoBehaviour
{
    public GameObject menu;
    static public bool estaPausado;

    // Start is called before the first frame update
    void Start()
    {
        
        menu = Instantiate(menu, menu.transform.position, menu.transform.rotation) as GameObject;
        Pause(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(!estaPausado);
        }
        
    }

    void Pause(bool statusPause)
    {
        estaPausado = statusPause;
        menu.SetActive(estaPausado);

        if (estaPausado)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
