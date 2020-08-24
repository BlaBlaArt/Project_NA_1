using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public List<GameObject> Enemys;

    public int EnemySpawnCount = 2;

    public float StartSpawn_Time;
    public float NextWaveSpawn_Time;

    private void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    private void SpawnEnemys(GameObject SpawnPoint)
    {
        GameObject tmpEnemy = Instantiate<GameObject>(Enemys[Random.Range(0,Enemys.Count)]);
        tmpEnemy.transform.position = SpawnPoint.transform.position;
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(StartSpawn_Time);
        for(int spawnCount = 1; spawnCount <= EnemySpawnCount; spawnCount++)
        {
            SpawnEnemys(SpawnPoints[Random.Range(0, SpawnPoints.Count)]);
        }
        yield return new WaitForSeconds(NextWaveSpawn_Time);
    }
}
