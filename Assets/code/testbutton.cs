using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testbutton : MonoBehaviour
{
    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Gamemanager.Instance.coin = 0;
        Gamemanager.Instance.hp = 0f;
    }
}
