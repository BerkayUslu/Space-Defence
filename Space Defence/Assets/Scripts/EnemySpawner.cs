using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonAllWaves());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SummonAllWaves()
    {
        for (int index = 0; index < waves.Count; index++)
        {
            yield return StartCoroutine(SummmonEnemiesInWave(waves[index]));
            yield return new WaitForSeconds(4f);
        }

    }
    private IEnumerator SummmonEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            GameObject enemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
