using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torque : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float tr;
    void Start()
    {
       rb = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        settq(40.0f);
        rtorque.settq(40.0f);

        Vector3 t = new Vector3 (0.0f, tr, 0.0f);
        rb.AddRelativeTorque(t);
    }

    void settq(float t)
    {
        tr=t;
    }
}
