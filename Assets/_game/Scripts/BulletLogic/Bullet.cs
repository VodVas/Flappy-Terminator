using UnityEngine;
using System;
using System.Collections;

public abstract class Bullet : MonoBehaviour, IDeathEvent
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] private float _lifeTime = 3f;

    private Coroutine _lifeCoroutine;

    public event Action<IDeathEvent> Dead;

    public virtual void Update()
    {
    }

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

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
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
        yield return new WaitForSeconds(_lifeTime);

        TriggerDeath();
    }
}