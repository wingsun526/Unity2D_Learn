using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    WaveConfigSO currentWave;
    
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWace()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform); // call object on runtime
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);



    }
    
}
