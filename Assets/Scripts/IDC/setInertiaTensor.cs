using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInertiaTensor : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 inertiaTensor;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.inertiaTensor = inertiaTensor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
