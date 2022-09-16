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

    //���� ���� ���� ǥ��
    private void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();

    //������ ����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //����Ǹ� ȣ��
    public override void OnConnectedToMaster()
    {
        print("�������ӿϷ�");
        string nickName = PhotonNetwork.LocalPlayer.NickName;
        nickName = NickNameInput.text;
        print("����� �г����� " + nickName + " �Դϴ�.");
        connect = true;
    }

    //�������
    public void Disconnect() => PhotonNetwork.Disconnect();

    //���� �������� ȣ��
    public override void OnDisconnected(DisconnectCause cause) => print("�������");

    //�� ����
    public void JoinRoom()
    {
        if (connect)
        {
            PhotonNetwork.JoinRandomRoom();
            uiPanel.SetActive(false);
            LoginUI.SetActive(true);
            print(roomNameInput.text + "�濡 �����ϼ̽��ϴ�.");
        }
    }

    //���� �� ���� ���н� ���ο� �� ���� (master �� ����)
    public override void OnJoinRandomFailed(short returnCode, string message) =>
        PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions { MaxPlayers = userNum });

    //�濡 ���� ���� �� ȣ��
    public override void OnJoinedRoom()
    {
        GameObject player_main = PhotonNetwork.Instantiate("Player", playerPos, Quaternion.identity);
        main_camera.transform.parent = player_main.transform;
        //main_camera.transform.position = player_main.transform.position;
    }
}
