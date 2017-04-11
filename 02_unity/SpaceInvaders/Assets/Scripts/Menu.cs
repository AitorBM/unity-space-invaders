using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string accion;

	// Use this for initialization
	void Start () {
        /*
        if (accion == "empezar")
        {
            empezar();
        } else
        {
            salir();
        }
        */
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void empezar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void salir()
    {
        Application.Quit();
    }
}
