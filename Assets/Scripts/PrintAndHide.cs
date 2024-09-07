using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrintAndHide : MonoBehaviour {
    public Renderer rend;
    int i, randValue;

    private void Awake()
    {
	    rend = transform.GetChild(0).GetComponent<MeshRenderer>();
	    Debug.Log("Awake() : " + rend);
	    Debug.Log("Get Test : " + this + " " + transform.GetChild(0));
    }

    // Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
        i = 0;
        randValue = Random.Range(200, 251);
        if (rend.enabled == false)
        {
	        rend.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        i++;
        //Debug.Log(gameObject.name + " : " + i);

        if (gameObject.CompareTag("Red") && i == 100)
            gameObject.SetActive(false);
        if (gameObject.CompareTag("Blue") && i == randValue)
            rend.enabled = false;
            
	}
}
