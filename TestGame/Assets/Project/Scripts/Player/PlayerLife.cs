using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            PlayerDeath();
    }

    public int GetHealthValue()
    {
        return health;
    }

    private void PlayerDeath()
    {
        Destroy(gameObject);
        GameManager.PlayerDie.Invoke();
    }
}