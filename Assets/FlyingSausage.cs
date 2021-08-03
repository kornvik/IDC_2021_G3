using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSausage : MonoBehaviour
{
    // Start is called before the first frame update
    private float tx, ty, tz, fx, fy, fz;
    private Rigidbody rb;
    // private PhotonView photonView;
    void Start()
    {

        rb=this.GetComponent<Rigidbody>();
        // photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(!photonView.IsMine)
            // return;

        fx=0.0f;
        fy=0.0f;
        fz=0.0f;
        tx=0.0f;
        ty=0.0f;
        tz=0.0f;
        if (Input.GetKey(KeyCode.W))
            fx= 10.0f;
        if (Input.GetKey(KeyCode.S))
            fx = -10.0f;
        if (Input.GetKey(KeyCode.A))
            fy= 10.0f;
        if (Input.GetKey(KeyCode.D))
            fy = -10.0f;
        if (Input.GetKey(KeyCode.P))
            fz= 10.0f;
        if (Input.GetKey(KeyCode.L))
            fz = -10.0f;

        // if (Input.GetKey(KeyCode.D))
        //     tx= 10.0f;
        // if (Input.GetKey(KeyCode.A))
        //     tx = -10.0f;
        if (Input.GetKey(KeyCode.Q))
            ty= 10.0f;
        if (Input.GetKey(KeyCode.E))
            ty = -10.0f;
        // if (Input.GetKey(KeyCode.E))
        //     tz= 10.0f;
        // if (Input.GetKey(KeyCode.Z))
        //     tz = -10.0f;
        Debug.Log(fx);
        Vector3 f= new Vector3 (fx, fy, fz);
        //rb.AddRelativeForce(f);
        rb.AddForce(f);
        Vector3 t= new Vector3 (tx, ty, tz);
        //rb.AddRelativeTorque(t);
        rb.AddTorque(t);
    }
}
