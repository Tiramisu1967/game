
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : BaseManager
{
    public GameObject[] Enemy;
    public GameObject Meteor;
    public GameObject BossA;
    public Transform[] EnemySpawnTransform;
    public float CoolDownTime;
    private int[] bin;
    public int MaxSpawn;
    public int BossSpawnCount;
    private int _spawnCount;
    private bool _bSpawnBoss;

    public override void Init(GameManager gameManger)
    {
        base.Init(gameManger);
        StartCoroutine(SpawnEnemy());
    }



    IEnumerator SpawnEnemy()
    {
        while (!_bSpawnBoss)
        {
            yield return new WaitForSeconds(CoolDownTime);
            List<int> position = new List<int>(EnemySpawnTransform.Length);

            for(int i = 0; i < EnemySpawnTransform.Length; i++)
            {
                position.Add(i);
            }

            for(int i = 0; i < MaxSpawn; i++)
            {
                int randomEnemy = Random.Range(0, Enemy.Length);
                int index = Random.Range(0, position.Count - 1);
                int randomPosition = position[index];
                
                position.RemoveAt(index);
                Instantiate(Enemy[randomEnemy], EnemySpawnTransform[randomPosition].position, Quaternion.identity);
            }
            _spawnCount++;
            if(_spawnCount == BossSpawnCount)
            {
                _bSpawnBoss = true;
            }
        }
        if (_bSpawnBoss)
        {
            Instantiate(BossA, EnemySpawnTransform[Random.Range(0, EnemySpawnTransform.Length)].position, Quaternion.identity);
        }

    }

    IEnumerator MeteorSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            int spawnCount = Random.Range(1, EnemySpawnTransform.Length - 1);
            List<int> availablePositions = new List<int>(EnemySpawnTransform.Length);

            for (int i = 0; i < EnemySpawnTransform.Length; i++)
            {
                availablePositions.Add(i);
            }

            for (int i = 0; i < spawnCount; i++)
            {
                int randomPositionIndex = Random.Range(0, availablePositions.Count - 1);
                int randomPosition = availablePositions[randomPositionIndex];

                availablePositions.RemoveAt(randomPositionIndex);

                Instantiate(Meteor, EnemySpawnTransform[randomPosition].position, Quaternion.identity);
            }
        }
    }
}
