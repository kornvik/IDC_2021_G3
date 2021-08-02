using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AxleInfo
{
    public WheelCollider FrontLeftWheel, FrontRightWheel, RearLeftWheel, RearRightWheel;
    public bool motor;
    public bool steering;
}

public class Tire : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    WheelCollider col = null;

    public GameObject flyer;
    public GameObject camera;

    void Start()
    {
        Debug.Log("Car starts !");
        Debug.Log(col);
        col = GetComponent<WheelCollider>();
        Debug.Log(col);
        ApplyLocalPositionToVisuals(col);

    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    void Update()
    {

    }


    // 対応する視覚的なホイールを見つけます
    // Transform を正しく適用します
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
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
        float steering = maxSteeringAngle; //* Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Escape)) Quit();

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //Debug.Log("Aボタンを押した");
            Quit();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Xボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            Debug.Log("Yボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            Debug.Log("メニューボタン（左アナログスティックの下にある）を押した");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("右人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            Debug.Log("右中指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Debug.Log("左人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("左中指トリガーを押した");
        }
        Rigidbody rb = flyer.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Vector3 position = flyer.transform.position;
            //position.y = position.y + (float)0.1;
            //flyer.transform.position = position;
            
            Vector3 force = new Vector3 (0.0f,9.8f*2.0f, 0.0f);

            rb.AddRelativeForce(force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Vector3 position = flyer.transform.position;
            //position.y = position.y - (float)0.1;
            //flyer.transform.position = position;
            Vector3 force = new Vector3 (0.0f, -9.8f,0.0f);

            rb.AddRelativeForce(force);
        }

        if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Keypad4))
        {
            Vector3 euler = camera.transform.rotation.eulerAngles;
            if (Input.GetKey(KeyCode.Keypad6))
                euler.x = euler.x + 1.0f;
            else
                euler.x = euler.x - 1.0f;
            camera.transform.rotation = Quaternion.Euler(euler);
        }

        if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.Keypad2))
        {
            Vector3 euler = camera.transform.rotation.eulerAngles;
            if (Input.GetKey(KeyCode.Keypad8))
                euler.y = euler.y + 1.0f;
            else
                euler.y = euler.y - 1.0f;
            camera.transform.rotation = Quaternion.Euler(euler);
        }

        if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Keypad3))
        {
            Vector3 euler = camera.transform.rotation.eulerAngles;
            if (Input.GetKey(KeyCode.Keypad7))
                euler.z = euler.z + 1.0f;
            else
                euler.z = euler.z - 1.0f;
            camera.transform.rotation = Quaternion.Euler(euler);
        }
        foreach (AxleInfo axleInfo in axleInfos)
        {
            // 左手のアナログスティックの向きを取得
                Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
                // 右手のアナログスティックの向きを取得
                Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

            if (axleInfo.steering)
            {
                axleInfo.FrontLeftWheel.steerAngle = 0.0f;
                axleInfo.FrontRightWheel.steerAngle = 0.0f;

                axleInfo.FrontLeftWheel.steerAngle = stickR.x*45.0f;
                axleInfo.FrontRightWheel.steerAngle = stickR.x*45.0f;

                // if (Input.GetKey(KeyCode.LeftArrow))
                // //if (OVRInput.Get(OVRInput.RawButton.A))
                // {
                //     axleInfo.FrontLeftWheel.steerAngle = -steering;
                //     axleInfo.FrontRightWheel.steerAngle = -steering;
                // }


                // if (Input.GetKey(KeyCode.RightArrow))
                // //if (OVRInput.Get(OVRInput.RawButton.B))
                // {
                //     axleInfo.FrontLeftWheel.steerAngle = steering;
                //     axleInfo.FrontRightWheel.steerAngle = steering;
                // }

            }
            if (axleInfo.motor)
            {
                axleInfo.FrontLeftWheel.motorTorque = stickR.y*motor*2.0f;
                axleInfo.FrontRightWheel.motorTorque = stickR.y*motor*2.0f;
                /*if(Input.GetKey(KeyCode.LeftArrow))
                    axleInfo.leftWheel.motorTorque = motor;
                else 
                    axleInfo.leftWheel.motorTorque = 0.0f;
                if(Input.GetKey(KeyCode.RightArrow))
                    axleInfo.rightWheel.motorTorque = motor;
                else 
                    axleInfo.rightWheel.motorTorque = 0.0f;
                    */
            }
            ApplyLocalPositionToVisuals(axleInfo.FrontLeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.FrontRightWheel);
            ApplyLocalPositionToVisuals(axleInfo.RearLeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.RearRightWheel);
        }
    }
}

