using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
