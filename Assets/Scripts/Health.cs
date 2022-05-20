using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int startLives = 30;
    public TextMeshProUGUI livesText;

    public static int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            lives = 0;
            StartCoroutine(GetComponent<GameOver>().GameOverLose());
        }
    }
    public static void LoseLife(int amount = 1)
    {
        lives -= amount;
    }
}
