using System.Collections;
using UnityEngine;

public class PlayerBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootInterval = 1f;
    [SerializeField] private float _speed = 30f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Shoot());
        }
    }

    protected override Vector3 GetSpawnPosition()
    {
        return _spawnPoint.position;
    }

    protected override void SpawnObject()
    {
        Bullet bullet = _objectPool.Get();

        bullet.transform.position = GetSpawnPosition();

        if (bullet.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = transform.right * _speed;
        }
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shootInterval);

        SpawnObject();

        yield return wait;
    }
}