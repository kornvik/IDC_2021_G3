using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Motor_con_L : MonoBehaviour
{
    // Start is called before the first frame update
    private HingeJoint hinge = null;

    public PhotonView photonView;
    // private JointMotor jointmotor ;
    private float force = 5.0f;
    private float maxAng = 60f;
    private float minAng = -30f;

    private int isClose = 1;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        photonView = this.GetComponent<PhotonView>();
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
        if (photonView.IsMine)
        {
            var motor = hinge.motor;
            if (Input.GetKey(KeyCode.Z))
            {
                Debug.Log("Open");
                motor.force = force;
                motor.targetVelocity = -40;
            }
            else if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("Close");
                motor.force = force;
                motor.targetVelocity = 40;
            }
            else if(Input.GetKey(KeyCode.C))
            {
                if(isClose==0) isClose = 1;
                else if(isClose==1) isClose =2;
                else isClose =1;
            }
            else
            {
                // Debug.Log("Non");
                if(isClose==0){
                    motor.force = force;
                    motor.targetVelocity = 0;
                } 
                else if(isClose == 1){
                    motor.force = force;
                    motor.targetVelocity = -40;
                }
                else
                {
                    motor.force = force;
                    motor.targetVelocity = 40;
                }
                
            }
            motor.freeSpin = false;
            hinge.motor = motor;
        }
    }
}
