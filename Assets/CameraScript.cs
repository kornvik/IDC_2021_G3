using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraRig;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){

            if (Input.GetKey(KeyCode.Y))
                        cameraRig.SetActive(true);
            
            if(Input.GetKey(KeyCode.T))
                        cameraRig.SetActive(false);
        }
    }
}


