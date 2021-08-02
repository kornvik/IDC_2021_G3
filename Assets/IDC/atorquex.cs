using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atorquex : MonoBehaviour
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

        settq(tr);
        artorque.settq(tr);

        Vector3 t = new Vector3 (tr, 0.0f, 0.0f);
        rb.AddRelativeTorque(t);
    }

    public void settq(float t)
    {
        tr=t;
    }
}
