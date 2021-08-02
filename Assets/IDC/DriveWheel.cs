using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AxleInfoD
{
    public WheelCollider Wheel;
    public bool motor;
    public bool steering;
}

public class DriveWheel : MonoBehaviour
{
    public List<AxleInfoD> axleInfos;
    public float maxMotorTorque;
    
    public float power;

    WheelCollider col = null;

    void Start()
    {
        col = GetComponent<WheelCollider>();
        Debug.Log(col);
        ApplyLocalPositionToVisualsD(col);

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
       
        foreach (AxleInfoD axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.Wheel.motorTorque = power*motor;
            }
            ApplyLocalPositionToVisualsD(axleInfo.Wheel);
            
        }
    }
}

