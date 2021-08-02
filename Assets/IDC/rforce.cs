using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rforce : MonoBehaviour
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
       Vector3 f = new Vector3 (0.0f, 0.0f, -fc);
        rb.AddRelativeForce(f);
    }

    public static void setfc(float f)
    {
        fc=f;
    }
    
}


