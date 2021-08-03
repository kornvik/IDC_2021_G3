using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class aforce : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    static float fc;
    public float cfc;
    public PhotonView photonView;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        cfc = -5.0f;
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
                   cfc = -1*cfc;
            }
            else 
            //if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKey(KeyCode.P))
                    cfc = 5.0f;
                if (Input.GetKey(KeyCode.L))
                    cfc = -5.0f;
            }
            

            setfc(cfc);
            arforce.setfc(cfc);

            Vector3 f = new Vector3(fc, 0.0f, 0.0f);
            rb.AddRelativeForce(f);
        }
    }

    static void setfc(float f)
    {
        fc = f;
    }
}

