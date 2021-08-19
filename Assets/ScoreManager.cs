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
    public GameObject elevator = null; // 
    public AudioSource audio;
    public bool start = false;
    bool counter_flag = false;
    float initialTime, currentTime, y0;
    public AudioClip clip;
    
    Text watch_text = null;


    Rigidbody rgb;
    void Start()
    {
        //rgb = elevator.GetComponent<Rigidbody>();
        y0 = elevator.transform.position.y;
        Debug.Log(y0);
        
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
            audio.Play(2);
        }

        if (counter_flag)
        {
            int min, sec;
            float starttime = 45.0f;

            currentTime = Time.time - initialTime;
            if (currentTime <= 120.99f) {
                min = (int)(currentTime / 60.0f);
                sec = (int)(currentTime - min * 60.0f);
                watch_text.text = min.ToString() + ":" + sec.ToString();
                if (currentTime >= starttime && currentTime < starttime + 30.0f)
                 {
                    Vector3 tmp;
                    tmp = elevator.transform.position;
                     tmp.y = y0 + (currentTime - starttime) * 0.50f;
                     elevator.transform.position = tmp;
                 }
                 if (currentTime >= 120.0f)
                {
                    start = false;
                    audio.Stop();
                    audio.PlayOneShot(clip);
                    
                 }
            }
        }
    }
}
