using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;

    public int currentWaveIndex = 0;
    public int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        enemiesKilled = waves[currentWaveIndex].amount;

        for (int i = 0; i < waves[currentWaveIndex].amount; i++)
        {
            float x = Random.Range(transform.position.x - 3, transform.position.x + 3);
            float y = Random.Range(transform.position.y - 3, transform.position.y + 3);
            Vector3 randomPos = new Vector3(x, y, 0);

            int randomEnemyIndex = Random.Range(0, waves[currentWaveIndex].prefab.Length);

            Instantiate(waves[currentWaveIndex].prefab[randomEnemyIndex], randomPos, transform.rotation, transform);
        }

        //Invoke("SpawnWave", waves[currentWaveIndex].time);

        //if (currentWaveIndex >= waves.Length-1)
        //{
        //    currentWaveIndex = 0;
        //}
        //else
        //{
        //    currentWaveIndex++;
        //}
        
    }

    public void OnEnemyKilled()
    {

        enemiesKilled--;

        if (enemiesKilled <= 0)
        {
            // completed wave
            currentWaveIndex++;
            SpawnWave();
        }
    }
}

[System.Serializable]
public class Wave 
{
    public GameObject[] prefab;
    public int amount;
    //public float time;
}
