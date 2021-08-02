using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rg = this.GetComponent<Rigidbody>();
        Vector3 t = new Vector3 (0.0f, 0.0f, 10.0f);
        rg.AddRelativeTorque(t);  
    }
}
