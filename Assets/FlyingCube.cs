using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class FlyingCube : MonoBehaviour
{
    // Start is called before the first frame update
    private float tx, ty, tz, fx, fy, fz,dtx,dty,dtz;
    private Rigidbody rb;
    public PhotonView photonView;
    // private PhotonView photonView;
    // [SerializeField]
    // [Range(0,20)]
    public float Kp = 1,Ki=0,Kd=0;
    private float error=0,prev_error=0,targety=2,ex=0,ez=0;
    private float p=0,i=0,d=0;
    private float initialy=0;
    void Start()
    {

        rb=this.GetComponent<Rigidbody>();
        photonView = this.GetComponent<PhotonView>();
        // targety = rb.position[1];
        initialy = rb.position[1];
        // prevy = initialy;
        // targety = 0; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(!photonView.IsMine)
            // return;

        fx=0.0f;
        fy=0.0f;
        fz=0.0f;
        tx=0.0f;
        ty=0.0f;
        tz=0.0f;
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.D))
                fx= 5.0f;
            else if (Input.GetKey(KeyCode.A))
                fx = -5.0f;
            else 
                fx = -rb.velocity[0]*0.6F;
            if (Input.GetKey(KeyCode.P))
            {
                targety += 0.01F;
                fy= 5.0f;
            }
            else if (Input.GetKey(KeyCode.L)&& targety>initialy)
            {
                targety -= 0.01F;
                fy = -5.0f;
            }
            else 
                fy = -rb.velocity[1]*0.8F;
            if (Input.GetKey(KeyCode.W))
                fz= 5.0f;
            else if (Input.GetKey(KeyCode.S))
                fz = -5.0f;
            else
                fz = -rb.velocity[2]*0.6F;

            if (targety<initialy)
                targety = initialy;
            // fy = p*(targety-rb.position[1]);
            
            // if (Input.GetKey(KeyCode.D))
            //     tx= 10.0f;
            // if (Input.GetKey(KeyCode.A))
            //     tx = -10.0f;
            if (Input.GetKey(KeyCode.Q))
                ty= 3.0f;
            else if (Input.GetKey(KeyCode.E))
                ty = -3.0f;
            else 
                ty = -rb.angularVelocity[1]*0.6F;
        }
        // if (Input.GetKey(KeyCode.E))
        //     tz= 10.0f;
        // if (Input.GetKey(KeyCode.Z))
        //     tz = -10.0f;
        // Debug.Log(fx);
        Quaternion rot = rb.rotation;
        Vector3 ang = rb.angularVelocity;
        ex = rot[0];
        ez = rot[2];
        tx = -ex*Kp;
        tz = -ez*Kp;
        
        // ty = 0.0f;
        Debug.Log(ex.ToString() + " " + ez.ToString());
        Vector3 nf = new Vector3(0,rb.mass * Mathf.Abs(Physics.gravity.y),0);
        rb.AddForce(nf);
        Vector3 f= new Vector3 (fx, fy, fz);
        //rb.AddRelativeForce(f);
        rb.AddForce(f);
        Vector3 t= new Vector3 (tx, ty, tz);
        //rb.AddRelativeTorque(t);
        rb.AddTorque(t);
    }
    // void FixedUpdate()
    // {
        
        
        
       
        // Vector3 t= new Vector3 (tx, ty, tz);
        //rb.AddRelativeTorque(t);
        // rb.AddTorque(t);
    //     error = targety-rb.position[1];
    //     p = error;
    //     i += (p)*(0.02F);
    //     d = error-(prev_error)*0.02F;
    //     prev_error = error;
    //     fx=0.0f;
    //     fz=0.0f;
    //     fy = Kp*p+Ki*(i)+Kd*(d);
    //     if(fy>20) fy = 20;
    //     if(fy<-20) fy=-20;
    //     Debug.Log(fy.ToString() + " " + p.ToString() + " " + i.ToString()+ " " + d.ToString());
    //     Debug.Log("---------");
    //     Vector3 f= new Vector3 (fx, fy, fz);
    //     rb.AddForce(f);
    // }

}
