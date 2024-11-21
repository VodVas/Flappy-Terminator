using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IDeathEvent
{
    [SerializeField] protected T _objectPrefab;

    protected ObjectPool<T> _objectPool;

    protected virtual void Start()
    {
        _objectPool = new ObjectPool<T>(CreateObject, OnGetFromPool, OnReleaseToPool, OnDestroyPoolObject, true, 10,20);
    }

    private void OnDisable()
    {
        _objectPool.Clear();
    }

    protected abstract Vector3 GetSpawnPosition();

    protected virtual T CreateObject()
    {
        T obj = Instantiate(_objectPrefab, GetSpawnPosition(), Quaternion.identity);

        return obj;
    }

    protected virtual void OnGetFromPool(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.Dead += HandleObjectDeath;
    }

    protected virtual void OnReleaseToPool(T obj)
    {
        obj.Dead -= HandleObjectDeath;
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(T obj)
    {
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }
    }

    protected virtual void HandleObjectDeath(IDeathEvent deadObject)
    {
        _objectPool.Release((T)deadObject);
    }

    protected virtual void SpawnObject()
    {
        T obj = _objectPool.Get();

        obj.transform.position = GetSpawnPosition();
    }
}