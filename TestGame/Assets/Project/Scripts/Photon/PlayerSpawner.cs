using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Collider2D planeCollider2D;
    private GameObject _player;
    private PhotonView _view;

    private void Awake()
    {
        _player = PhotonNetwork.Instantiate(playerPrefab.name, RandomPointInBounds(planeCollider2D.bounds),
            Quaternion.identity);
        _view = GetComponent<PhotonView>();
        _view.RPC("AddPlayerFromList", RpcTarget.AllBuffered, _player);
    }

    private static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

    public GameObject ReturnPlayerObject()
    {
        return _player;
    }
}