using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class G3_rotateCover : MonoBehaviour
{
    private HingeJoint hinge = null;
    public PhotonView photonView;
    private bool isMove = false;
    private float in_ang;
    public float force = 5.0f;
    // Start is called before the first frame update
      void Start()
    {
        hinge = GetComponent<HingeJoint>();
        photonView = this.GetComponent<PhotonView>();
        // Make the hinge motor rotate with 90 degrees per second and a strong force.
        var motor = hinge.motor;
        motor.force = 1.0f;
        motor.targetVelocity = 90;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        in_ang = hinge.angle;
    }
    void Update()
    {
        
        if (photonView.IsMine)
        {
            var motor = hinge.motor;
            if (Input.GetKey(KeyCode.F))
            {
                // Debug.Log("Open");
                isMove = true;
                motor.force = force;
                motor.targetVelocity = 40;
            }
            else if (Input.GetKey(KeyCode.R))
            {
                // Debug.Log("Close");
                isMove = true;
                motor.force = force;
                motor.targetVelocity = -40;
            }
            else
            {
                // Debug.Log("Non"); 
                if(!isMove){
                    motor.targetVelocity = in_ang - hinge.angle;
                } else {
                    motor.targetVelocity = 0;
                }
                motor.force = 5;
                
                
            }
            motor.freeSpin = false;
            hinge.motor = motor;
        }
    }
}
