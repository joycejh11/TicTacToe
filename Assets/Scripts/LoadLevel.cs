using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Load2Player()
    {
        GameScript.isSinglePlayer = false;
        GameScript.isEasy = false;
        SceneManager.LoadScene("play");        
    }

    public void Load1Player()
    {
        GameScript.isEasy = true;
        GameScript.isSinglePlayer = true;
        SceneManager.LoadScene("play");
    }

    public void ReloadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
