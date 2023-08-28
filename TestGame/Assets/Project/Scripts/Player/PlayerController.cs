using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TMP_Text nickName;
    private PhotonView _view;

    public Joystick joystick;
    private Rigidbody2D _playerRb;
    private float _speed = 5f;
    private float _rotationSpeed = 720f;
    private int _coinsCount;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _playerRb = GetComponent<Rigidbody2D>();
        _view.RPC("NickName", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        nickName.text = PhotonNetwork.NickName;
    }

    private void FixedUpdate()
    {
        MoveLogic(joystick.Horizontal, joystick.Vertical);
    }

    public void MoveLogic(float x, float y)
    {
        if (_view.IsMine)
        {
            _playerRb.velocity = new Vector2(x, y).normalized * _speed;
            if (x == 0 && y == 0) return;
            var toRotation = Quaternion.LookRotation(Vector3.forward, _playerRb.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed);
        }
    }

    [PunRPC]
    private void NickName(string nick)
    {
        nickName.text = nick;
    }

    public void AddCoin()
    {
        _coinsCount++;
    }

    public int ReturCoinsCount()
    {
        return _coinsCount;
    }
}