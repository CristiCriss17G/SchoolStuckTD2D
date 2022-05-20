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

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI enemiesKilledText;

    void Start()
    {
        coins = startCoins;
        fontSize = coinsText.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + coins;
        if(GetComponent<WaveSpanner>().bossLevel)
            enemiesKilledText.text = "Score: " + enemiesKilled;
    }

    public void Pulse()
    {
        coinsText.color = Color.red;
        coinsText.fontSize = textSizeToPulse;
        Invoke(nameof(ResetButton), textSpeed);
    }

    void ResetButton()
    {
        coinsText.color = Color.white;
        coinsText.fontSize = fontSize;
    }
}
