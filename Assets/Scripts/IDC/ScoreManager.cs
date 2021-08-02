using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject score_object = null; // Textオブジェクト
    //public GameObject elevator = null; // 

    public bool start = false;
    bool counter_flag = false;
    float initialTime, currentTime, y0;
    
    Text watch_text = null;


    Rigidbody rgb;
    void Start()
    {
        //rgb = elevator.GetComponent<Rigidbody>();
        //y0 = elevator.transform.position.y;
        //Debug.Log(y0);
        
        watch_text = score_object.GetComponent<Text>();
        //watch_text.text = "Which side ?: ";
       
    }

    // Update is called once per frame
    void Update()
    {
        Player[] otherPlayers = PhotonNetwork.PlayerListOthers;
        //Debug.Log(otherPlayers.Length);
        if (!counter_flag && start)
        {
            counter_flag = true;
            initialTime = Time.time;
        }

        if (counter_flag)
        {
            int min, sec;
            

            currentTime = Time.time-initialTime;
            min = (int)(currentTime / 60.0f);
            sec = (int)(currentTime - min * 60.0f);
            watch_text.text = min.ToString() + ":" + sec.ToString();
            // if(currentTime >= 30.0f && currentTime < 60.0f){
            //     Vector3 tmp;
            //     tmp = elevator.transform.position;
            //     tmp.y = y0 + (currentTime-30.0f)*0.50f;
            //     elevator.transform.position=tmp;
            // }
        }
    }
}
