using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCover : MonoBehaviour
{
    private HingeJoint hinge = null;

    public float force = 0.06f;
    // Start is called before the first frame update
      void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // Make the hinge motor rotate with 90 degrees per second and a strong force.
        var motor = hinge.motor;
        motor.force = 0.06f;
        motor.targetVelocity = 90;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
    }
    void Update()
    {
        var motor = hinge.motor;
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("Open");
            motor.force = force;
            motor.targetVelocity = 40;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Close");
            motor.force = force;
            motor.targetVelocity = -40;
        }
        else
        {
            // Debug.Log("Non"); 
            motor.force = force;
            motor.targetVelocity = 0;
        }
        motor.freeSpin = false;
        hinge.motor = motor;
    }
}
