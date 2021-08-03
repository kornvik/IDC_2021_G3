using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする

public class MultiPlay2_org : MonoBehaviourPunCallbacks
{
    public Text RobotnameR1, RobotnameB1;
    int Playstart = 0;
    private PhotonView photonView;

    int PlayerCount;
    InputField inputField1;
    Text text1;

    Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 orientation = new Vector3(0.0f, 0.0f, 0.0f);
    Text Robotname;

    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        photonView = PhotonView.Get(this);
        PlayerCount = 0;

        //inputField1 = GetComponent<InputField>();
        //text1 = text1.GetComponent<Text>();
    }
    // このメソッドをOn Value Changeに指定すると文字変更があった時に呼び出される
    public void OnValueChange()
    {
        text1.text = inputField1.text;
        Debug.Log(inputField1.text);  // 入力された文字を表示
    }

    // このメソッドをEnd Editに指定すると入力が確定した時に呼び出される
    public void EndEdit()
    {
        text1.text = inputField1.text;
        // if (inputField1.text = "a") inputField1.text = "";  // 入力文字制限
        Debug.Log(inputField1.text);  // 入力された文字を表示
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
        //Debug.Log(Time.time);
        if (Input.GetKey(KeyCode.Escape)) Quit();
        // while(true) {
        //     if (PhotonNetwork.CountOfPlayersOnMaster < 2 && Playstart == 1)
        //         continue;
        //     else
        //         break;   

        // }
        PlayerCount = PhotonNetwork.CountOfPlayers;
        //Debug.Log(PlayerCount);
    }


    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        //RoomInfo [] roomInfo = PhotonNetwork.GetRoomList();
        //if (roomInfo == null || roomInfo.Length == 0) return;

        if (photonView.IsMine)
        {
            Player[] otherPlayers = PhotonNetwork.PlayerListOthers;

            if (otherPlayers.Length <= 0)
                PlayerCount = 1;
            else
                PlayerCount = 2;

        }

        // var position = new Vector3(0.0f, 0.0f, 0.0f);
        // var orientation = new Vector3(0.0f, 0.0f, 0.0f);
        //PhotonNetwork.Instantiate("Objects", position, Quaternion.identity);
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        //position =  new Vector3(-19.3f + 3.0f*(photonView.OwnerActorNr-1), 3.13f, 18f);
        // if (PlayerCount == 2 )
        // {
        //     position = new Vector3(-4.11f-18.0f, 2.4f, 0.0f+4.0f);
        //     orientation = new Vector3(0.0f, -90.0f, 0.0f);
        // PhotonNetwork.Instantiate(Robotname.text, position, Quaternion.Euler(orientation));
        // position.y = position.y + 3.0f;
        // position.z = position.z + 6.0f;
        // PhotonNetwork.Instantiate("Flyer2", position, Quaternion.identity);
        // }
        // else {
        //     position = new Vector3(4.11f+18.0f, 2.4f, 0.0f+12.0f);
        //     orientation = new Vector3(0.0f, 90.0f, 0.0f);
        //     PhotonNetwork.Instantiate("Cart1", position, Quaternion.Euler(orientation));
        //     position.y = position.y + 3.0f;
        //     PhotonNetwork.Instantiate("Flyer2", position, Quaternion.Euler(orientation));
        // }
    }

    public void StartRobotR1()
    {

        position = new Vector3(4.11f + 18.0f, 2.4f, 0.0f + 12.0f);
        orientation = new Vector3(0.0f, 90.0f, 0.0f);
        PhotonNetwork.Instantiate(RobotnameR1.text, position, Quaternion.Euler(orientation));
        // position.y = position.y + 3.0f;
        // PhotonNetwork.Instantiate("Flyer2", position, Quaternion.Euler(orientation));

    }

    public void StartRobotB1()
    {
        var position = new Vector3(0.0f, 0.0f, 0.0f);
        var orientation = new Vector3(0.0f, 0.0f, 0.0f);

        position = new Vector3(-4.11f - 18.0f, 2.4f, 0.0f + 4.0f);
        orientation = new Vector3(0.0f, -90.0f, 0.0f); PhotonNetwork.Instantiate(RobotnameB1.text, position, Quaternion.Euler(orientation));
        position.y = position.y + 3.0f;
        position.z = position.z + 6.0f;
        // PhotonNetwork.Instantiate("Flyer2", position, Quaternion.identity);
    }
}

