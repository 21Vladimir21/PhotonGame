using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
     private Slider _slider;
     private PlayerLife _playerLife;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _playerLife.GetHealthValue();
        
    }

    private void LateUpdate()
    {
        _slider.value = _playerLife.GetHealthValue();
    }

    public void SetPlayerLife(PlayerLife playerLife)
    {
        _playerLife = playerLife;
    }

    private void OnDestroy()
    {
        _slider.value = 0;
    }
}