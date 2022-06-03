using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public int Decreaseblood;

    public Text textblood;


    void Update()
    {
        Gamemanager.Instance.hp = int.Parse(textblood.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gamemanager.Instance.hp -= Decreaseblood;
            textblood.text = Gamemanager.Instance.hp.ToString();

        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

        }
    }
}
