using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraControll : MonoBehaviour
{
    public GameObject cameraFamily;
    public GameObject body2;
    public GameObject cameraRear;
    public GameObject cameraFront;
    public GameObject cameraLeft;
    public GameObject cameraRight;
    public PhotonView photonView;
    public Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        cameraFront.SetActive(true);
        cameraRear.SetActive(false);
        cameraRight.SetActive(false);
        cameraLeft.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        vector3 = body2.transform.position;
        vector3.y += 2.34f;
        cameraFamily.transform.position = vector3;

        if (photonView.IsMine)
        {
            
            if (Input.GetKey(KeyCode.Alpha1))
            {
                cameraFront.SetActive(true);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(true);
                cameraLeft.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(true);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                cameraFront.SetActive(false);
                cameraRear.SetActive(false);
                cameraRight.SetActive(false);
                cameraLeft.SetActive(false);
            }
        }
    }
}