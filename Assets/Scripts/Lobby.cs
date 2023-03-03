using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.MUIP;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Lobby : MonoBehaviourPunCallbacks
{
    public ButtonManager CreateRoomButton;
    public ButtonManager JoinRoomButton;
    public ButtonManager StartGameButton;
    public CustomInputField JoinRoomCode;

    public TextMeshProUGUI RoomCodeText;

    public TextMeshProUGUI AllPlayersConnectedNames;

    private void Start()
    {
        PhotonNetwork.JoinLobby();

        CreateRoomButton.onClick.AddListener(OnClickCreateRoom);
        JoinRoomButton.onClick.AddListener(OnClickJoinRoom);
        StartGameButton.onClick.AddListener(OnClickStartGame);
    }

    public void OnClickStartGame()
    {
        PhotonNetwork.LoadLevel("Playground");
    }

    public void OnClickCreateRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }

        CreateRoomButton.normalText.text = "Creating...";
        CreateRoomButton.buttonText = "Creating...";
        CreateRoomButton.isInteractable = false;
        
        string randomRoomName = Random.Range(0, 999999).ToString("000000"); 

        PhotonNetwork.CreateRoom(randomRoomName, new Photon.Realtime.RoomOptions {MaxPlayers = 4});
    }

    public void OnClickJoinRoom()
    {
        JoinRoomButton.normalText.text = "Joining...";
        JoinRoomButton.buttonText = "Joining...";
        JoinRoomButton.isInteractable = false;

        PhotonNetwork.JoinRoom(JoinRoomCode.inputText.text);
    }

    public override void OnJoinedRoom()
    {
        RoomCodeText.text = PhotonNetwork.CurrentRoom.Name;
        RefreshPlayerList();
    }

    public void EnableStartButton()
    {
        if (PhotonNetwork.PlayerList.Length > 0 && PhotonNetwork.IsMasterClient)
        {
            StartGameButton.isInteractable = true;
            StartGameButton.gameObject.SetActive(true);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RefreshPlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RefreshPlayerList();
    }

    public void RefreshPlayerList()
    {
        EnableStartButton();
        AllPlayersConnectedNames.text = "";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            AllPlayersConnectedNames.text += player.NickName + "\n";
        }
    }
}