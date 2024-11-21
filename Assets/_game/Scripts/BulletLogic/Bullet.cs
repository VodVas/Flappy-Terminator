using UnityEngine;
using System;
using System.Collections;

public abstract class Bullet : MonoBehaviour, IDeathEvent
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] private float _lifeTime = 3f;

    private Coroutine _lifeCoroutine;

    public event Action<IDeathEvent> Dead;

    private void OnEnable()
    {
        _lifeCoroutine = StartCoroutine(LifeDuration());
    }

    private void OnDisable()
    {
        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);

            _lifeCoroutine = null;
        }
    }

    protected void TriggerDeath()
    {
        if (Dead != null)
        {
            Dead.Invoke(this);

            Dead = null;
        }
    }

    protected virtual IEnumerator LifeDuration()
    {
        var wait = new WaitForSeconds(_lifeTime);

        yield return wait;

        TriggerDeath();
    }
}