using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TextSync : MonoBehaviourPun
{
[SerializeField]
Text text;//同期させるTextをインスペクターから割り当てる

[PunRPC]//RPCを使って呼べるようにするにはこの属性をつける(これが無いと呼べない)
void SetText (string value)
{
text.text = value;
}
}
