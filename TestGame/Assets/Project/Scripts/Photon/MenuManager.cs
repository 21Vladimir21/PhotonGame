using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createInputField;
    [SerializeField] private TMP_InputField _joinInputField;
    [SerializeField] private TMP_InputField playerNickManeField;

    private void Awake()
    {
        if (PhotonNetwork.NickName == "")
            PhotonNetwork.NickName = "User";
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(_createInputField.text, roomOptions);
    }

    public void SetNickName()
    {
        PhotonNetwork.NickName = playerNickManeField.text;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}