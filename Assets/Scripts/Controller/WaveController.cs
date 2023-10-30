using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class WaveController : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 randomPosition;
    public int Count;
    public int SpawnEnemy;
    public int CountWave;
    public EnemyController EnemyController;
    private void Awake()
    {
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        {
            Count += 1;
        });
    }
   
    void Update()
    {
        if (Count >= SpawnEnemy)
        {
            Count = 0;
           
            CountWave++;

            if(CountWave < 3)
            {
                SpawmEnemy();
            }
        }
        if(CountWave == 3)
        {
            this.PostEvent(EventID.EndWave);   
            CountWave = 0;
            //EnemyController.Uplevel();
            Debug.Log("aaaaaa");
        }
    }
    public void SpawmEnemy()
    {        
        for (int i = 0; i < SpawnEnemy; i++)
        {
            float RandomX = Random.Range(0, 10);
            float RandomY = Random.Range(0, 10);
            randomPosition = new Vector3(RandomX, RandomY);

            var e = SmartPool.Instance.Spawn(enemy.gameObject, randomPosition, Quaternion.identity);
            e.transform.localScale = new Vector3(2, 2, 1);           
        }
        
    }
    public void BonusSpawn()
    {
        SpawnEnemy += 1;
    }
}
