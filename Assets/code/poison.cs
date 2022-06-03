using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poison : MonoBehaviour
{
    public Text textblood;
    void Update()
    {
        Gamemanager.Instance.hp = int.Parse(textblood.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gamemanager.Instance.hp -= 100f * Time.deltaTime;
            textblood.text = Gamemanager.Instance.hp.ToString();


        }
    }
}
