using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class YouWinScreen : MonoBehaviour
{
    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level2");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

