using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("IDC game is started !");
    }
void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();

        if (Input.GetKey(KeyCode.Keypad1)){
           Debug.Log ("Key1"); 
        }

        if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
            Debug.Log ("button1");
        }
        if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
            Debug.Log ("button2");
        }

        float hori = Input.GetAxis ("Mouse X");
        
        float vert = Input.GetAxis ("Vertical");
        if(( hori != 0) ||  (vert != 0) ){
            Debug.Log ("stick:"+hori+","+vert );
        }
    }
}
