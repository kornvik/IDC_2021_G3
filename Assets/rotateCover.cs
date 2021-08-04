using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class rotateCover : MonoBehaviour
{
    private HingeJoint hinge = null;
    public PhotonView photonView;

    public float force = 0.06f;
    // Start is called before the first frame update
      void Start()
    {
        hinge = GetComponent<HingeJoint>();
        photonView = this.GetComponent<PhotonView>();
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
        
        if (photonView.IsMine)
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
}
