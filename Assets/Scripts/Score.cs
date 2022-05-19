using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int enemiesKilled = 0;
    public static int coins = 0;

    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Coins: " + coins;
    }
}
