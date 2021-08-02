using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    static float fc;

    void Start()
    {
       rb = this.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
       setfc(4f);
        rforce.setfc(4f);

        Vector3 t = new Vector3 (0.0f, 0.0f, fc);
        rb.AddRelativeTorque(t);
    }

    static void setfc(float f)
    {
        fc = f;
    }
}

