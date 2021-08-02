using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artorque : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    static float tr;
    void Start()
    {
       rb = GetComponent<Rigidbody>(); //this.GetComponent<Rigidbody>(); 
       Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 t = new Vector3 (0.0f, -tr, 0.0f);
        rb.AddRelativeTorque(t);
    }

    static public void settq(float t)
    {
        tr=t;
    }
}
