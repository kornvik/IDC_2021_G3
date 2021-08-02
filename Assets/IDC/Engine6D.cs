using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine6D : MonoBehaviour
{
    // Start is called before the first frame update
    public float tx, ty, tz, fx, fy, fz;
    private Rigidbody rb;
    void Start()
    {
        fx=0.0f;
        fy=0.0f;
        fz=0.0f;
        tx=0.0f;
        ty=0.0f;
        tz=0.0f;
        rb=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 f= new Vector3 (fx, fy, fz);
        //rb.AddRelativeForce(f);
        rb.AddForce(f);
        Vector3 t= new Vector3 (tx, ty, tz);
        //rb.AddRelativeTorque(t);
        rb.AddTorque(t);
    }

}
