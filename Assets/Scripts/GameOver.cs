using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public AudioSource win;
    public AudioSource lose;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameOverWin()
    {
        Debug.Log("Level Complete");
        GetComponent<WaveSpanner>().enabled = false;
        win.Play();

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("WinGame");
    }

    public IEnumerator GameOverLose()
    {
        GetComponent<WaveSpanner>().enabled = false;
        /*gameOverUI.SetActive(true);*/
        GameObject[] enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemiesLeft)
        {
            Destroy(enemy);
        }

        lose.Play();

        yield return new WaitForSeconds(5);

        var GM = GameObject.FindGameObjectWithTag("GameMaster");
        
        if(GM.GetComponent<WaveSpanner>().bossLevel)
        {
            PlayerPrefs.SetInt("BossScore",Score.enemiesKilled);
            SceneManager.LoadScene("GameOver");
        }
        else
            SceneManager.LoadScene("GameOver");
    }
}
