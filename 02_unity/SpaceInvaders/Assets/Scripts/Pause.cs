using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool paused;
    public float a;

    // Use this for initialization
    void Start () {
        paused = false;
        a = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("p"))
        {
            if (paused)
            {
                Time.timeScale = a;
                paused = false;
            }
            else
            {
                Time.timeScale = 0;
                paused = true;
            }

        }
    }
}
