using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private GameObject marcador;
	// Use this for initialization
	void Start () {
		marcador = GameObject.Find ("Marcador");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void empezar()
    {
		Destroy(marcador);
        SceneManager.LoadScene("Nivel1");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void multi()
    {
		Destroy(marcador);
        SceneManager.LoadScene("Nivel1Multi");
    }

	public void menu()
	{
		Destroy(marcador);
		SceneManager.LoadScene("Menu");
	}
}
