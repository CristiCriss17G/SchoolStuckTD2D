using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpanner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public int maxEnamies = 100;

    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;
    private int enemyIndex = 0;
    private float enemyDelay = 0.5f;

    private int enemyHealth;

    void Start()
    {
        enemyHealth = enemyPrefab[0].GetComponent<Enemy>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            /*StartCoroutine(SpawnWave());*/
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        int enemyCount = waveIndex;
        if (waveIndex > 5)
        {
            enemyCount = Random.Range(waveIndex, waveIndex * 2);
            enemyDelay = Random.Range(0.1f, 1f);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemyDelay);
        }
    }

    void SpawnEnemy()
    {
        if (enemyIndex <= maxEnamies)
        {
            int enemyChooseIndex = Random.Range(0, enemyPrefab.Length);
            GameObject currentEnemy = Instantiate(enemyPrefab[enemyChooseIndex], spawnPoint.position, spawnPoint.rotation);
            /*Debug.Log("Enemy health expected: " + enemyHealth);*/
            currentEnemy.GetComponent<Enemy>().health = enemyHealth;
            /*Debug.Log("Enemy health actual: " + currentEnemy.GetComponent<Enemy>().health);*/
            enemyIndex++;
            if (enemyIndex > 0 && enemyIndex % 5 == 0)
            {
                enemyHealth += 5;
            }
        }
        if (enemyIndex > maxEnamies && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Health.lives > 0)
        {
            Debug.Log("Wave complete");
            /*enemyIndex = 0;*/
            enemyHealth = enemyPrefab[0].GetComponent<Enemy>().maxHealth;
            GetComponent<GameOver>().GameOverWin();
            this.enabled = false;
        }
    }
}
