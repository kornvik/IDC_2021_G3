using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepadcheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float vert = Input.GetAxis("Horizontal");
        float hori = Input.GetAxis("Vertical");

        Debug.Log("stick:" + hori + "," + vert);

        if(Input.GetKeyDown("1")) {
            Debug.Log("Fire1");
        }
        if(Input.GetKeyDown("2")) {
            Debug.Log("Fire2");
        }
    }
}
    
