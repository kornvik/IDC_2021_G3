using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_con_L : MonoBehaviour
{
    // Start is called before the first frame update
    private HingeJoint hinge = null;
    // private JointMotor jointmotor ;
    public float force = 0.06f;
    public float maxAng = 90f;
    public float minAng = -90f;
    void Awake()
    {
        // controls.Player.CounterClock.performed += _ => CounterClock();
        // controls.Player.Clock.performed += _ => Clock();
    }
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // Make the hinge motor rotate with 90 degrees per second and a strong force.
        var motor = hinge.motor;
        var limit = hinge.limits;
        motor.freeSpin = false;
        limit.max = maxAng;
        limit.min= minAng;
        hinge.motor = motor;
        hinge.limits = limit;
        hinge.useMotor = true;
        hinge.useLimits = true;
    }
    // void CounterClock()
    // {
    //     Debug.Log("CounterClock!");
    // }

    // void Clock()
    // {
    //     Debug.Log("Clock!");
    // }

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
