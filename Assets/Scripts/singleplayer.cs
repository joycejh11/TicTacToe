using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singleplayer : MonoBehaviour {
   
    public void single()
    {
        GameScript.isSinglePlayer = true;
        SceneManager.LoadScene("Difficulty");
    }
}
