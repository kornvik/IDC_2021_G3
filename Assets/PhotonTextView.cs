using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotonTextView : MonoBehaviour, IPunObservable
{
    public string score;
    private PhotonView photonView;
    public InputField inputField;

    public Text text;

    // public string Text
    // {
    //     get { return text.text; }
    //     set { text.text = value; RequestOwner(); }
    // }

    void Awake()
    {
        this.photonView = GetComponent<PhotonView>();
    }

void Update(){
    score = inputField.text;
}
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("Photon !");
        // オーナーの場合
        if (stream.IsWriting)
        {
            stream.SendNext(score);
            text.text = score;
        }
        // オーナー以外の場合
        else
        {
            
            text.text = (string)stream.ReceiveNext();
        }
    }

    // private void RequestOwner()
    // {
    //     if (this.photonView.IsMine == false)
    //     {
    //         if (this.photonView.OwnershipTransfer != OwnershipOption.Request)
    //             Debug.LogError("OwnershipTransferをRequestに変更してください。");
    //         else
    //             this.photonView.RequestOwnership();
    //     }
    // }
}