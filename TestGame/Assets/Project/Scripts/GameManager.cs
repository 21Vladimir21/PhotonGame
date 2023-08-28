using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    private PhotonView _view;

    public static readonly UnityEvent PlayerDie = new UnityEvent();

    private void Awake()
    {
        PlayerDie.AddListener(EndGame);
        _view = GetComponent<PhotonView>();
    }

    public void BackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Menu");
    }


    private void EndGame()
    {
        _view.RPC("Wait", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private IEnumerator Wait()
    {
        endGamePanel.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}