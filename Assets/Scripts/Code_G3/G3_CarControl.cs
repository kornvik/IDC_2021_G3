using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

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
    private float maxMotorTorque = 3; // maximum torque the motor can apply to wheel
    public float maxSpin; // maximum steer angle the wheel can have

    public PhotonView photonView;
   
    private float brakeVal = 4;

    private float brake;

    // finds the corresponding visual wheel
    // correctly applies the transform
    void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
        visualWheel.transform.Rotate(0f, 0f, 90f);
    }
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();

    }
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxMotorTorque/3 * Input.GetAxis("Horizontal");
            // Debug.Log(steering.ToString());
            float lmotor = steering;
            float rmotor = -steering;
            // lmotor += steering;
            // rmotor -= steering;
            brake = 0;
            if (Input.GetKey(KeyCode.Space) == true){
                brake = brakeVal;
            }
            // Debug.Log(brake.ToString() + " " +  motor.ToString());
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
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
                
            }
        }
    }
}
    
