using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class G3_CarCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraFamily;
    public GameObject body2;
    public GameObject cameraRear;
    public GameObject cameraFront;
    public GameObject cameraLeft;
    public GameObject cameraRight;
    public GameObject cameraTop;
    public PhotonView photonView;
    public Vector3 vector3;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            cameraFront.SetActive(true);
            cameraRear.SetActive(false);
            cameraRight.SetActive(false);
            cameraLeft.SetActive(false);
            cameraTop.SetActive(false);
        } else{
            cameraFront.SetActive(false);
            cameraRear.SetActive(false);
            cameraRight.SetActive(false);
            cameraLeft.SetActive(false);
            cameraTop.SetActive(false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (photonView.IsMine)
        {
            vector3 = body2.transform.position;
            rot = body2.transform.rotation;
            // Debug.Log(vector3.ToString());
            // vector3.y += 2.34f;
            cameraFamily.transform.position = vector3;
            cameraFamily.transform.rotation = rot;
            if (Input.GetKey(KeyCode.Alpha5))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);
                cameraTop.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(true);
                cameraLeft.SetActive(false);
                cameraTop.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(true);
                cameraTop.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(true);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);       
                cameraTop.SetActive(false);     
            }
            else if (Input.GetKey(KeyCode.Alpha1))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);
                cameraTop.SetActive(false);
            }
        }
    }
}
