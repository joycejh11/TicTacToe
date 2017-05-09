using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

    public GameObject Camera;
    public static GameScript Script;
    public int Index;

    void Awake()
    {
        Script = Camera.GetComponent<GameScript>();
    }

    void OnMouseDown()
    {    
        Script.SpawnNew(this);
    }
}
