using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlCamara : MonoBehaviour
{
	// Referencia al objeto en la escena
	//private GameObject alien;

	// Velocidad a la que se desplaza el alien
	private float velocidad = 5f;

	// Use this for initialization
	void Start ()
	{
		// Conectamos con la instancia que hemos creado en el editor
		//alien = GameObject.Find ("Alien1");

        // Calculamos la anchura visible de la cámara en pantalla
        //float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        //Reescalo la imágen unsando la anchura visible
        transform.localScale = new Vector2(Camera.main.pixelWidth/10, Camera.main.pixelHeight/10);
        
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Time.deltaTime != 0)
        {
            for (int i = 0; i < Camera.main.pixelHeight/2; i++)
            {
                transform.Translate(new Vector2(0, -0.0001f));
            }
        }

        if (!SceneManager.GetActiveScene().name.Equals("Menu") && !SceneManager.GetActiveScene().name.Equals("GameOver"))
        {
            // Tecla: Izquierda
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * Time.deltaTime * velocidad);
            }

            // Tecla: Derecha
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * Time.deltaTime * velocidad);
            }
        }
	}
}
