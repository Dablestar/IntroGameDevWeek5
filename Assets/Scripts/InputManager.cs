using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;

    // Start is called before the first frame update
    void Start()
    {
        transArray = new Transform[2];
        transArray[0] = GameObject.FindWithTag("Red").transform;
        transArray[1] = GameObject.FindWithTag("Blue").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transArray[0].Rotate(0, 0, 45);
            transArray[1].Rotate(0,0,-45);
            
        }

        if (Input.GetButtonDown("Fire1") && transArray[0] != null && transArray[1] != null)
        {
            transArray[0].position = new Vector3(transArray[0].position.x, transArray[0].position.y * -1, transArray[0].position.z);
            transArray[1].position = new Vector3(transArray[1].position.x, transArray[1].position.y * -1, transArray[1].position.z);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log(transArray[0].GetComponent<PrintAndHide>());
            float redRandColorVal = Random.Range(51.0f, 250.1f) / 255, blueRandColorVal = Random.Range(51.0f, 250.1f) / 255;
            transArray[0].GetComponent<PrintAndHide>().rend.material.color = new Color(redRandColorVal, 0.0f, 0.0f);
            transArray[1].GetComponent<PrintAndHide>().rend.material.color = new Color(0.0f, 0.0f, blueRandColorVal);
            Debug.Log("Red:" + transArray[0].GetComponent<PrintAndHide>().rend.material.color);
            Debug.Log("Blue:" + transArray[1].GetComponent<PrintAndHide>().rend.material.color);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            PrintAndHide redScript = transArray[0].GetComponent<PrintAndHide>();
            PrintAndHide blueScript = transArray[1].GetComponent<PrintAndHide>();

            if (redScript == null)
            {
                transArray[0].gameObject.AddComponent<PrintAndHide>();
                transArray[0].gameObject.SetActive(true);
                transArray[1].gameObject.SetActive(true);
            }
            else
            {
                Destroy(redScript);
            }

            if (blueScript == null)
            {
                transArray[1].gameObject.AddComponent<PrintAndHide>();
                transArray[0].gameObject.SetActive(true);
                transArray[1].gameObject.SetActive(true);
            }
            else
            {
                Destroy(blueScript);
            }
        }
    }
}
