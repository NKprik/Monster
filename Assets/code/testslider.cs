using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testslider : MonoBehaviour
{
    public float Timeout;
    
    void Update()
    {
        GetComponent<Slider>().value = 1f-(Time.timeSinceLevelLoad/Timeout);


        if (Time.timeSinceLevelLoad>=Timeout)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
