﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GeneradorAliens : MonoBehaviour
{

	// Publicamos la variable para conectarla desde el editor
	public Rigidbody2D prefabAlien1;
    public Rigidbody2D prefabAlien2;

    // Referencia para guardar una matriz de objetos
    private Rigidbody2D[,] aliens;

	// Tamaño de la invasión alienígena
	private const int FILAS = 4;
	private const int COLUMNAS = 7;

	// Enumeración para expresar el sentido del movimiento
	private enum direccion { IZQ, DER };

	// Rumbo que lleva el pack de aliens
	private direccion rumbo = direccion.DER;

	// Posición vertical de la horda (lo iremos restando de la .y de cada alien)
	private float altura = 0.007f;

	// Límites de la pantalla
	private float limiteIzq;
	private float limiteDer;

	// Velocidad a la que se desplazan los aliens (medido en u/s)
	private float velocidad = 2f;

	// Use this for initialization
	void Start ()
	{
		// Rejilla de 4x7 aliens
		generarAliens (FILAS, COLUMNAS, 1.5f, 1.0f);

		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla (añadimos una unidad a cada lado como margen)
		limiteIzq = -1.0f * distanciaHorizontal + 1;
		limiteDer = 1.0f * distanciaHorizontal - 1;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel2":
                velocidad = 4f;
                break;

            case "Nivel3":
                velocidad = 5f;
                break;

            case "Nivel4":
                velocidad = 6f;
                break;

            case "NivelFinal":
                velocidad = 7f;
                break;

            case "Nivel1Multi":
                velocidad = 2f;
                break;

            case "Nivel2Multi":
                velocidad = 4f;
                break;

            case "Nivel3Multi":
                velocidad = 5f;
                break;

            case "Nivel4Multi":
                velocidad = 6f;
                break;

            case "NivelFinalMulti":
                velocidad = 7f;
                break;

            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("m")) {
			
		}

		// Contador para saber si hemos terminado
		int numAliens = 0;

		// Variable para saber si al menos un alien ha llegado al borde
		bool limiteAlcanzado = false;

		// Recorremos la horda alienígena
		for (int i = 0; i < FILAS; i++) {
			for (int j = 0; j < COLUMNAS; j++) {

				// Comprobamos que haya objeto, para cuando nos empiecen a disparar
				if (aliens [i, j] != null) {

					// Un alien más
					numAliens += 1;

					// ¿Vamos a izquierda o derecha?
					if (rumbo == direccion.DER) {

						// Nos movemos a la derecha (todos los aliens que queden)
						aliens [i, j].transform.Translate (Vector2.right * velocidad * Time.deltaTime);

						// Comprobamos si hemos tocado el borde
						if (aliens [i, j].transform.position.x > limiteDer) {
							limiteAlcanzado = true;
						}
					} else {

						// Nos movemos a la derecha (todos los aliens que queden)
						aliens [i, j].transform.Translate (Vector2.left * velocidad * Time.deltaTime);

						// Comprobamos si hemos tocado el borde
						if (aliens [i, j].transform.position.x < limiteIzq) {
							limiteAlcanzado = true;
						}
					}		
				}
			}
		}

		// Si no quedan aliens, hemos terminado
		if( numAliens == 0 ) {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Nivel1":
                    SceneManager.LoadScene("Nivel2");
                    break;

                case "Nivel2":
                    SceneManager.LoadScene("Nivel3");
                    break;

                case "Nivel3":
                    SceneManager.LoadScene("Nivel4");
                    break;

                case "Nivel4":
                    SceneManager.LoadScene("NivelFinal");
                    break;

                case "NivelFinal":
                    SceneManager.LoadScene("Victoria");
                    break;

                case "Nivel1Multi":
                    SceneManager.LoadScene("Nivel2Multi");
                    break;

                case "Nivel2Multi":
                    SceneManager.LoadScene("Nivel3Multi");
                    break;

                case "Nivel3Multi":
					SceneManager.LoadScene("Nivel4Multi");
                    break;

                case "Nivel4Multi":
                    SceneManager.LoadScene("NivelFinalMulti");
                    break;

                case "NivelFinalMulti":
                    SceneManager.LoadScene("VictoriaMulti");
                    break;

                default:
                    break;
            }
		}

		// Si al menos un alien ha tocado el borde, todo el pack cambia de rumbo
		if (limiteAlcanzado == true) {
			


			if (rumbo == direccion.DER) {
				rumbo = direccion.IZQ;
			} else {
				rumbo = direccion.DER;
			}
		}
		for (int i = 0; i < FILAS; i++) {
			for (int j = 0; j < COLUMNAS; j++) {

				// Comprobamos que haya objeto, para cuando nos empiecen a disparar
				if (aliens [i, j] != null && Time.timeScale != 0) {
					aliens[i,j].transform.Translate (Vector2.down * altura);
				}
			}
		}
	}

	void generarAliens (int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
	{
		/* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

		// Calculamos el punto de origen de la rejilla
		Vector2 origen = new Vector2 (transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

		// Instanciamos el array de referencias
		aliens = new Rigidbody2D[filas, columnas];

		// Fabricamos un alien en cada posición del array
		for (int i = 0; i < filas; i++) {
			for (int j = 0; j < columnas; j++) {

				// Posición de cada alien
				Vector2 posicion = new Vector2 (origen.x + (espacioH * j), origen.y + (espacioV * i));

                Rigidbody2D alien;

                if (i % 2 == 0 && j % 2 ==0)
                {
                    // Instanciamos el objeto partiendo del prefab
                    alien = (Rigidbody2D)Instantiate(prefabAlien1, posicion, transform.rotation);
                }
                else{
                    // Instanciamos el objeto partiendo del prefab
                    alien = (Rigidbody2D)Instantiate(prefabAlien2, posicion, transform.rotation);
                }

				// Guardamos el alien en el array
				aliens [i, j] = alien;

				// Escala opcional, por defecto 1.0f (sin escala)
				// Nota: El prefab original ya está escalado a 0.2f
				alien.transform.localScale = new Vector2 (0.2f * escala, 0.2f * escala);
			}
		}

	}

}
