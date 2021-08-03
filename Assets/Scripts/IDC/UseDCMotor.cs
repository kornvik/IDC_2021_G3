using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UseDCMotor : MonoBehaviour
{
    public atorque motor;
    public PhotonView photonView;
    // Start is called before the first frame update

    float tr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (photonView.IsMine)
        {
            tr = 0.0f;
            
            if (Application.platform == RuntimePlatform.Android)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.A))
                {
                    tr = 10.0f;
                }
                if (OVRInput.GetDown(OVRInput.RawButton.B))
                {
                    tr = -10.0f;
                }
            }
            else
            //if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKey(KeyCode.O))
                    tr = 10.0f;
                if (Input.GetKey(KeyCode.K))
                    tr = -10.0f;
            }
           
        //    motor.tr = tr;
        //    motor.DCMotorOn();
            
        }  
    }
}
