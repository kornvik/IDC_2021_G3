using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Motor_prac : MonoBehaviour
{
    // Start is called before the first frame update
    // public InputMaster controls;
    private bool holdFire1 = false;
    private bool holdFire2 = false;
    private HingeJoint hinge = null;
    // private JointMotor jointmotor ;
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
        limit.max = 90;
        limit.min=-90;
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
        if (Input.GetButton("E"))
        {
            Debug.Log("Fire1");
            motor.force = 0.06F;
            motor.targetVelocity = 10;
        }
        else if (Input.GetButton("Q"))
        {
            Debug.Log("Fire2");
            motor.force = 0.06F;
            motor.targetVelocity = -10;
        }
        else
        {
            Debug.Log("Non"); 
            motor.force = 0.06F;
            motor.targetVelocity = 0;
        }
        motor.freeSpin = false;
        hinge.motor = motor;
    }
    // Update is called once per frame
    void onEnable()
    {
        // controls.Enable();
    }

    void onDisable()
    {
        // controls.Disable();
    }
}
