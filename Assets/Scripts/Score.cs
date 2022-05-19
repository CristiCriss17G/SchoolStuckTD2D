using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int enemiesKilled = 0;
    public static int coins = 0;

    [Header("UI")]
    public int startCoins = 50;

    [Header("Text options")]
    public float textSpeed = 0.5f;
    public float textSizeToPulse = 50f;

    private float fontSize;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        coins = startCoins;
        fontSize = scoreText.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Coins: " + coins;
    }

    public void Pulse()
    {
        scoreText.color = Color.red;
        scoreText.fontSize = textSizeToPulse;
        Invoke(nameof(ResetButton), textSpeed);
    }

    void ResetButton()
    {
        scoreText.color = Color.white;
        scoreText.fontSize = fontSize;
    }
}
