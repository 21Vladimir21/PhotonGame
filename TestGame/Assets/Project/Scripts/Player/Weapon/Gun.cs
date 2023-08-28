using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    public void Shot()
    {
        PhotonNetwork.Instantiate(bullet.name, shotPoint.position,transform.rotation);
    }
}
