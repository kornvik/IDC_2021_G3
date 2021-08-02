using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class inputTeam : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField iField;
  public Text tx;

  void Start () {
    //Componentを扱えるようにする
        //iField = inputField.GetComponent<InputField> ();
        //tx = text.GetComponent<Text> ();

    }

    public void InputText(){
                //テキストにinputFieldの内容を反映
         tx.text = iField.text;

     }

}
