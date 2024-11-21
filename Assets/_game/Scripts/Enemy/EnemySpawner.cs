using UnityEngine;
using System.Collections;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private ScoreCounter _scoreKeeper;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay = 2f;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    protected override Enemy CreateObject()
    {
        Enemy enemy = Instantiate(_objectPrefab, GetSpawnPosition(), Quaternion.identity);

        enemy.Init(_scoreKeeper);

        return enemy;
    }

    protected override Vector3 GetSpawnPosition()
    {
        return _spawnPoint.position;
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            yield return wait;

            SpawnObject();
        }
    }
}