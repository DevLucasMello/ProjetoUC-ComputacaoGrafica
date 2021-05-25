using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour{

    public Text cronometro;
    public GameObject[] BotoesMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AtualizaCronometro(int segundos)
    {
        cronometro.text = segundos.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chamaCena() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Corrida");
    
    }
    public void chamaSair()
    {
        Application.Quit();
    }

    public void AtivarMenus(bool ativar) {

        for (int i = 0; i < BotoesMenu.Length; i++)
        {
            BotoesMenu[i].SetActive(ativar);
        }
            


    }
}
