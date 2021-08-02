using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtorque : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    static float tr;
    void Start()
    {
       rb = this.GetComponent<Rigidbody>(); 
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
