using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerSerialization : MonoBehaviour
{
   [SerializeField] private HealthBar healthBar;
   [SerializeField] private Joystick joystick;
   [SerializeField] private PlayerSpawner playerSpawner;
   [SerializeField] private TMP_Text coinsText;
   private GameObject _pLayer;
   private void Awake()
   {
      _pLayer = playerSpawner.ReturnPlayerObject();
      healthBar.SetPlayerLife(_pLayer.GetComponent<PlayerLife>());
      
      _pLayer.GetComponent<PlayerController>().joystick = joystick;
      
   }

   private void Update()
   {
       coinsText.text = _pLayer.GetComponent<PlayerController>().ReturCoinsCount().ToString();
   }

   public void ShotOnGun()
   {
       _pLayer.GetComponent<Gun>().Shot();
   }
}
