using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverWin()
    {
        Debug.Log("Level Complete");
        GetComponent<WaveSpanner>().enabled = false;
    }

    public void GameOverLose()
    {
        GetComponent<WaveSpanner>().enabled = false;
        /*gameOverUI.SetActive(true);*/
        GameObject[] enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemiesLeft)
        {
            Destroy(enemy);
        }
    }
}
