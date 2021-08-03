using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

[System.Serializable]

public class AxleInfoDL
{
    public WheelCollider Wheel;
    public bool motor;
    public bool steering;
}

public class DriveWheelL : MonoBehaviour
{
    public List<AxleInfoDL> axleInfos;
    public float maxMotorTorque;

    public float power;

    WheelCollider col = null;
    public PhotonView photonView;

    //void Awake() 
    //{} 
    void Start()
    {
        //col = GetComponent<WheelCollider>();
        //Debug.Log(col);
        //ApplyLocalPositionToVisualsD(col);
        //PhotonView = PhotonView.Get(this);  
        //PhotonView = GetComponent<PhotonView>(); 
    }

    void Update()
    {

    }


    // 対応する視覚的なホイールを見つけます
    // Transform を正しく適用します
    public void ApplyLocalPositionToVisualsD(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        //Debug.Log(rotation);
        visualWheel.transform.rotation = rotation;
        visualWheel.transform.Rotate(0f, 0f, 90f);
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque; //* Input.GetAxis("Vertical");


        if (photonView.IsMine)
        {

            foreach (AxleInfoDL axleInfo in axleInfos)
            {
                axleInfo.Wheel.motorTorque = 0.0f;

                // 右手のアナログスティックの向きを取得
                //ector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
                //if (Input.GetKey(KeyCode.Escape)) Quit();
                //
                // if (OVRInput.GetDown(OVRInput.RawButton.A))
                // {
                //     //Debug.Log("Aボタンを押した");
                //     Quit();
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.B))
                // {
                //     Debug.Log("Bボタンを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.X))
                // {
                //     Debug.Log("Xボタンを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.Y))
                // {
                //     Debug.Log("Yボタンを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.Start))
                // {
                //     Debug.Log("メニューボタン（左アナログスティックの下にある）を押した");
                // }

                // if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                // {
                //     Debug.Log("右人差し指トリガーを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
                // {
                //     Debug.Log("右中指トリガーを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
                // {
                //     Debug.Log("左人差し指トリガーを押した");
                // }
                // if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
                // {
                //     Debug.Log("左中指トリガーを押した");
                // }
                // Rigidbody rb = flyer.GetComponent<Rigidbody>();
                // if (Input.GetKey(KeyCode.UpArrow))
                // {
                //     //Vector3 position = flyer.transform.position;
                //     //position.y = position.y + (float)0.1;
                //     //flyer.transform.position = position;

                //     Vector3 force = new Vector3(0.0f, 9.8f * 2.0f, 0.0f);

                //     rb.AddRelativeForce(force);
                // }
                // if (Input.GetKey(KeyCode.DownArrow))
                // {
                //     //Vector3 position = flyer.transform.position;
                //     //position.y = position.y - (float)0.1;
                //     //flyer.transform.position = position;
                //     Vector3 force = new Vector3(0.0f, -9.8f, 0.0f);

                //     rb.AddRelativeForce(force);
                // }

                // if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Keypad4))
                // {
                //     Vector3 euler = camera.transform.rotation.eulerAngles;
                //     if (Input.GetKey(KeyCode.Keypad6))
                //         euler.x = euler.x + 1.0f;
                //     else
                //         euler.x = euler.x - 1.0f;
                //     camera.transform.rotation = Quaternion.Euler(euler);
                // }

                // if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.Keypad2))
                // {
                //     Vector3 euler = camera.transform.rotation.eulerAngles;
                //     if (Input.GetKey(KeyCode.Keypad8))
                //         euler.y = euler.y + 1.0f;
                //     else
                //         euler.y = euler.y - 1.0f;
                //     camera.transform.rotation = Quaternion.Euler(euler);
                // }

                // if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Keypad3))
                // {
                //     Vector3 euler = camera.transform.rotation.eulerAngles;
                //     if (Input.GetKey(KeyCode.Keypad7))
                //         euler.z = euler.z + 1.0f;
                //     else
                //         euler.z = euler.z - 1.0f;
                //     camera.transform.rotation = Quaternion.Euler(euler);
                // }

                if (axleInfo.motor)
                {
                    //axleInfo.Wheel.motorTorque = -10.0f;

                    float x, y;
                    x = 0.0f; y = 0.0f;

                    if (Application.platform == RuntimePlatform.Android)
                    {
                        // 左手のアナログスティックの向きを取得
                        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
                        // 右手のアナログスティックの向きを取得
                        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

                        x = stickR.x;
                        y = stickR.y;
                    }
                    else 
                    //if (Application.platform == RuntimePlatform.WindowsPlayer)
                    {

                        if (Input.GetKey(KeyCode.UpArrow))
                        {
                            y = 1.0f;
                            Debug.Log("UpArrow Button !");
                        }
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            y = -1.0f;
                        }
                        if (Input.GetKey(KeyCode.RightArrow))
                        {
                            x = 1.0f;
                        }
                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            x = -1.0f;
                        }
                    }
                    
                    

                    axleInfo.Wheel.motorTorque = (y - 2.0f * x) * maxMotorTorque;
                }
                ApplyLocalPositionToVisualsD(axleInfo.Wheel);

            }
        }
    }

    public override bool Equals(object obj)
    {
        return obj is DriveWheelL l &&
               base.Equals(obj) &&
               EqualityComparer<PhotonView>.Default.Equals(photonView, l.photonView);
    }

    public override int GetHashCode()
    {
        int hashCode = -164824088;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<PhotonView>.Default.GetHashCode(photonView);
        return hashCode;
    }
}

