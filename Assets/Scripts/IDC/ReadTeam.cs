using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTeam : MonoBehaviour
{
    // Start is called before the first frame update

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


