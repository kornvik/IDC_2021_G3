using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class G3_AxelInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    // public bool steering; // does this wheel apply steer angle?
}

public class G3_CarControl : MonoBehaviour
{
    public List<G3_AxelInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque = 1; // maximum torque the motor can apply to wheel
    public float maxSpin; // maximum steer angle the wheel can have

    
    public float brakeVal = 2;

    private float brake;
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxMotorTorque/3 * Input.GetAxis("Horizontal");
        Debug.Log(steering.ToString());
        float lmotor = steering;
        float rmotor = -steering;
        // lmotor += steering;
        // rmotor -= steering;
        brake = 0;
        if (Input.GetKey(KeyCode.Space) == true){
            brake = brakeVal;
        }
        Debug.Log(brake.ToString() + " " +  motor.ToString());
        // Debug.Log(kl.ToString()+" "+kr.ToString());
        foreach (G3_AxelInfo axleInfo in axleInfos) {
            // if (axleInfo.steering) {
            //     // axleInfo.leftWheel.steerAngle = steering;
            //     // axleInfo.rightWheel.steerAngle = steering;
            //     if(ste)
            // }
            if (axleInfo.motor) {
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
                if(brake==0){
                    axleInfo.leftWheel.motorTorque = motor + lmotor;
                    axleInfo.rightWheel.motorTorque = motor + rmotor;
                    Debug.Log("move " + motor.ToString()+ " " + lmotor.ToString());
                }
                
            }
            
        }
    }
}
    
