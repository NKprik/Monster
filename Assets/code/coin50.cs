﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin50 : MonoBehaviour
{
    public Text textcoin;

    private void Update()
    {
        Gamemanager.Instance.coin = int.Parse(textcoin.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gamemanager.Instance.coin += Gamemanager.Instance.increasecoin50;
            textcoin.text = Gamemanager.Instance.coin.ToString();
            Destroy(gameObject);
        }
    }
}