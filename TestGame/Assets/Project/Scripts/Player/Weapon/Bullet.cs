using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject obj = other.gameObject;
            other.GetComponent<PlayerLife>().TakeDamage(_damage);
        }

        if (!other.CompareTag("Ground"))
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            transform.Translate(Vector2.up * (_bulletSpeed * Time.fixedDeltaTime));
            Destroy(gameObject, 5f);
        }
    }
}