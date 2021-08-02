using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderCommand : MonoBehaviour
{
    public aforce  objGet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            objGet.cfc=5.0f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            objGet.cfc=-5.0f;
        }
    }
}
