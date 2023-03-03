using System.Collections;
using System.Collections.Generic;
using Michsky.MUIP;
using Photon.Pun;
using UnityEngine;

public class ServerConnect : MonoBehaviourPunCallbacks
{
    public CustomInputField PlayerName;
    public ButtonManager JoinRoomButton;

    public void OnClick()
    {
        PhotonNetwork.NickName = PlayerName.inputText.text;
        JoinRoomButton.normalText.text = "Connecting...";

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        // PhotonNetwork.JoinRandomRoom();
        JoinRoomButton.normalText.text = "Connected!";
        JoinRoomButton.buttonText = "Connected!";
        JoinRoomButton.isInteractable = false;
    }
}