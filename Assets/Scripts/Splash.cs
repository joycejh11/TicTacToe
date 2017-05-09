using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash : MonoBehaviour {

    public float timer;

    private void Update()
    {
        if(timer < 0.0f)
        {
            SceneManager.LoadScene("main");
        }
        timer -= Time.deltaTime;
    }
	

	
}
