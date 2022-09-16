using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject LoginUI = null;

    public Text StatusText;
    public InputField NickNameInput;
    public InputField roomNameInput;
    public GameObject uiPanel;
    public byte userNum = 5;
    Vector3 playerPos;

    public Camera main_camera;

    private bool connect = false;

    private void Start()
    {
        playerPos = new Vector3(13.51f, 0.5f, -12.0f);
    }

    //현재 접속 상태 표시
    private void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();

    //서버에 접속
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //연결되면 호출
    public override void OnConnectedToMaster()
    {
        print("서버접속완료");
        string nickName = PhotonNetwork.LocalPlayer.NickName;
        nickName = NickNameInput.text;
        print("당신의 닉네임은 " + nickName + " 입니다.");
        connect = true;
    }

    //연결끊기
    public void Disconnect() => PhotonNetwork.Disconnect();

    //연결 끊겼을때 호출
    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김");

    //방 입장
    public void JoinRoom()
    {
        if (connect)
        {
            PhotonNetwork.JoinRandomRoom();
            uiPanel.SetActive(false);
            LoginUI.SetActive(true);
            print(roomNameInput.text + "방에 입장하셨습니다.");
        }
    }

    //랜덤 룸 입장 실패시 새로운 방 생성 (master 방 생성)
    public override void OnJoinRandomFailed(short returnCode, string message) =>
        PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions { MaxPlayers = userNum });

    //방에 입장 했을 때 호출
    public override void OnJoinedRoom()
    {
        GameObject player_main = PhotonNetwork.Instantiate("Player", playerPos, Quaternion.identity);
        main_camera.transform.parent = player_main.transform;
        //main_camera.transform.position = player_main.transform.position;
    }
}
