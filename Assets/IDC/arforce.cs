using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arforce : MonoBehaviour
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
       Vector3 f = new Vector3 (-fc, 0.0f, 0.0f);
        rb.AddRelativeForce(f);
    }

    public static void setfc(float f)
    {
        fc=f;
    }
    
}


