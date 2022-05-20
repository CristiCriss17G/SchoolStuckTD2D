using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpanner : MonoBehaviour
{
    /*public static WaveSpanner instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }*/


    [Header("Wave Mode")]
    public bool bossLevel = false;

    [Header("Wave Objects")]
    public GameObject[] enemyPrefab;
    public Transform spawnPoint;

    [Header("Wave Settings")]
    public float timeBetweenWaves = 5f;

    public int maxEnamies = 100;

    public int waveTreshold = 5;

    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;
    private int enemyIndex = 0;
    private float enemyDelay = 0.5f;

    private int[] enemyHealth;

    private bool corutineStart;

    void Start()
    {
        enemyHealth = new int[enemyPrefab.Length];
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            enemyHealth[i] = enemyPrefab[i].GetComponent<Enemy>().health;
        }
        corutineStart = false;
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
        if(!bossLevel)
            waveCountdownText.text = "Enemy "+enemyIndex+'/'+maxEnamies;
        else
            waveCountdownText.text = "Enemy " + enemyIndex;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        int enemyCount = waveIndex;
        if (waveIndex > waveTreshold)
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
        if (!bossLevel && enemyIndex <= maxEnamies)
        {
            int enemyChooseIndex = 0;
            if (enemyIndex>waveTreshold)
            {
                enemyChooseIndex = Random.Range(0, enemyPrefab.Length);
            }
            GameObject currentEnemy = Instantiate(enemyPrefab[enemyChooseIndex], spawnPoint.position, spawnPoint.rotation);
            /*Debug.Log("Enemy health expected: " + enemyHealth);*/
            currentEnemy.GetComponent<Enemy>().health = enemyHealth[enemyChooseIndex];
            /*Debug.Log("Enemy health actual: " + currentEnemy.GetComponent<Enemy>().health);*/
            enemyIndex++;
            if (enemyIndex > 0 && enemyIndex % waveTreshold == 0)
            {
                enemyHealth[enemyChooseIndex] += 5;
            }
        }
        if (!bossLevel && enemyIndex > maxEnamies && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Health.lives > 0)
        {
            Debug.Log("Wave complete");
            /*enemyIndex = 0;*/
            for (int i = 0; i < enemyPrefab.Length; i++)
            {
                enemyHealth[i] = enemyPrefab[i].GetComponent<Enemy>().health;
            }
            if (!corutineStart)
            {
                corutineStart = true;
                StartCoroutine(GetComponent<GameOver>().GameOverWin());
            }
            this.enabled = false;
        }

        if(bossLevel)
        {
            int enemyChooseIndex = 0;
            if (enemyIndex > waveTreshold)
            {
                enemyChooseIndex = Random.Range(0, enemyPrefab.Length);
            }
            GameObject currentEnemy = Instantiate(enemyPrefab[enemyChooseIndex], spawnPoint.position, spawnPoint.rotation);
            /*Debug.Log("Enemy health expected: " + enemyHealth);*/
            currentEnemy.GetComponent<Enemy>().health = enemyHealth[enemyChooseIndex];
            /*Debug.Log("Enemy health actual: " + currentEnemy.GetComponent<Enemy>().health);*/
            enemyIndex++;
            if (enemyIndex > 0 && enemyIndex % waveTreshold == 0)
            {
                enemyHealth[enemyChooseIndex] += 5;
            }
        }
    }
}
