using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UseCylinder : MonoBehaviour
{
    // Start is called before the first frame update
    public aforce cylinder;
    public PhotonView photonView;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //cfc = 0.0f;
            if (Application.platform == RuntimePlatform.Android)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                    cylinder.cfc = -1 * cylinder.cfc;
            }
            else
            //if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKey(KeyCode.P))
                    cylinder.cfc = 5.0f;
                if (Input.GetKey(KeyCode.L))
                    cylinder.cfc = -5.0f;
            }

            // cylinder.CylinderOn();
        }
    }
}
