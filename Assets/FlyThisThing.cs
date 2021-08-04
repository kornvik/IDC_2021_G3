using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FlyThisThing : MonoBehaviour
{
    // Start is called before the first frame update
    public PhotonView photonView;
    private float tx, ty, tz, fx, fy, fz;
    private Rigidbody rb;
    // public PhotonView photonView;
    // private PhotonView photonView;
    // [SerializeField]
    // [Range(0,20)]
    public float Kp = 2,Ki=0,Kd=0;
    private float error=0,prev_error=0,targety=2,etx=0,etz=0,targetz=2,targetx=2,prev_etx=0,prev_etz=0;
    private float curx,cury,curz;
    private float p=0,i=0,d=0;
    private float ptx=0,itx=0,dtx=0;
    private float ptz=0,itz=0,dtz=0;
    private float initialy=0;

    public float stability = 1.0f;
    public float speed = 3.0f;
    void Start()
    {

        rb=this.GetComponent<Rigidbody>();
        photonView = this.GetComponent<PhotonView>();
        targety = rb.position[1];
        targetx = rb.position[0];
        targetz = rb.position[2];
        // initialy = rb.position[1];
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
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("pressed A");
                fx= 20.0f;
                targetx += 1.0f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("pressed D");
                fx = -20.0f;
                targetx -= 1.0f;
            }
            else 
                fx = -rb.velocity[0]*2.0F;
            if (Input.GetKey(KeyCode.P))
            {
                targety += 0.01F;
                fy= 15.0f;
            }
            else if (Input.GetKey(KeyCode.L)&& targety>initialy)
            {
                targety -= 0.01F;
                fy = -15.0f;
            }
            else 
                fy = -rb.velocity[1]*2.0F;
            if (Input.GetKey(KeyCode.S))
                fz= 20.0f;
            else if (Input.GetKey(KeyCode.W))
                fz = -20.0f;
            else
                fz = -rb.velocity[2]*2.0F;

            if (targety<initialy)
                targety = initialy;

            if (Input.GetKey(KeyCode.Q))
                ty= 15.0f;
            else if (Input.GetKey(KeyCode.E))
                ty = -15.0f;
            else 
                ty = -rb.angularVelocity[1]*1.0F;
        }
        
        //---------------------Hovering & Position Control ----------------------
        
        Vector3 nf = new Vector3(0,3.5f * Mathf.Abs(Physics.gravity.y),0);
        rb.AddForce(nf);
        Vector3 f= new Vector3 (fx, fy, fz);

        //----------------------- Rotation control ---------------------
        Quaternion rot = rb.rotation;
        Vector3 ang = rb.angularVelocity;
        etx = 0.0f-rot[0];
        etz = 0.0f-rot[2];
        ptx = etx;
        ptz = etz;
        itx += etx*0.02f;
        itz += etz*0.02f;
        dtx = (etx-prev_etx)/0.02f;
        dtz = (etz-prev_etz)/0.02f;
        Debug.Log(etx.ToString() + " " + etz.ToString());
        prev_etx = etx;
        prev_etz = etz;

        tx = ptx*Kp + itx*Ki + dtx*Kd;
        tz = ptz*Kp + itz*Ki + dtz*Kd;
        //rb.AddRelativeForce(f);
        rb.AddForce(f);
        Vector3 t= new Vector3 (tx, ty, tz);
        Debug.Log(ptx.ToString() + " " + ptz.ToString());
        Debug.Log("Torque " + tx.ToString() + " " + tz.ToString());
        
        Vector3 predictedUp = Quaternion.AngleAxis(rb.angularVelocity.magnitude*Mathf.Rad2Deg*stability/speed,rb.angularVelocity)*transform.up;
        Vector3 torqueVector = Vector3.Cross(predictedUp,Vector3.up);
        rb.AddTorque(torqueVector * speed * speed);
        // rb.AddRelativeTorque(t);
        // rb.AddTorque(t);
    }
}
