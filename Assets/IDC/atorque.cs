using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class atorque : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float tr;

    public PhotonView photonView;
    void Start()
    {
        rb = GetComponent<Rigidbody>();//this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (photonView.IsMine)
        // {
        //     tr = 0.0f;
            
        //     if (Application.platform == RuntimePlatform.Android)
        //     {
        //         if (OVRInput.GetDown(OVRInput.RawButton.A))
        //         {
        //             tr = 10.0f;
        //         }
        //         if (OVRInput.GetDown(OVRInput.RawButton.B))
        //         {
        //             tr = -10.0f;
        //         }
        //     }
        //     else
        //     //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //     {
        //         if (Input.GetKey(KeyCode.O))
        //             tr = 10.0f;
        //         if (Input.GetKey(KeyCode.K))
        //             tr = -10.0f;
        //     }
           
            

        //     settq(tr);
        //     artorque.settq(tr);

        //     Vector3 t = new Vector3(0.0f, tr, 0.0f);
        //     rb.AddRelativeTorque(t);
        // }
    }
public void DCMotorOn() //Don't change this function
    {
            float maxtorque = 0.06f;
            if(tr > maxtorque)
                tr = maxtorque;
            if(tr < -maxtorque)
                tr = -maxtorque;
            settq(tr);
            artorque.settq(tr);
            Debug.Log("in DCMotorOn "+tr);

            Vector3 t = new Vector3(0.0f, tr, 0.0f);
            rb.AddRelativeTorque(t);
    }

    public void settq(float t)
    {
        tr = t;
    }
}
