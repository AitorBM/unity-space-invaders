using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {

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

    public void multi()
    {
        SceneManager.LoadScene("Nivel1Multi");
    }

	public void menu()
	{
		SceneManager.LoadScene("Menu");
	}
}
