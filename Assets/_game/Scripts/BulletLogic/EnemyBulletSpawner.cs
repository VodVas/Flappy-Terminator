using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootDelay = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    protected override Vector3 GetSpawnPosition()
    {
        return _spawnPoint.position;
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootDelay);

            SpawnObject();
        }
    }
}