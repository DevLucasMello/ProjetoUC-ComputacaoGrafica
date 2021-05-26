using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class configGeral : MonoBehaviour
{
    public GameObject menu;
    static public bool estaPausado;
    Menu menuInicial;
    static public float tempoRestante;

  
    
    // Start is called before the first frame update
    void Start()
    {
        menu = Instantiate(menu, menu.transform.position, menu.transform.rotation) as GameObject;
        tempoRestante = 30;
        menuInicial = menu.GetComponent<Menu>();
        Pause(false);
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(!estaPausado);
        }

        tempoRestante -= Time.deltaTime;
        //if (tempoRestante<=0 || PlayerController.qtdVidas<0)
        if (tempoRestante<=0)
        {
            tempoRestante = 0;
            Pause(true);

        }
        menuInicial.AtualizaCronometro((int)Mathf.Round(tempoRestante));
        
    }

    void Pause(bool statusPause)
    {
        estaPausado = statusPause;
        menuInicial.AtivarMenus(estaPausado);

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
