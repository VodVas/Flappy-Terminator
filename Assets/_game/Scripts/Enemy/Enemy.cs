using UnityEngine;
using System;
using System.Collections;

public class Enemy : MonoBehaviour, IDeathEvent
{
    [SerializeField] private float _lifeTime = 5f;

    private ScoreCounter _scoreCounter;
    private Coroutine _lifeCoroutine;

    public event Action<IDeathEvent> Dead;

    private void OnEnable()
    {
        _lifeCoroutine = StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_lifeCoroutine);

        _lifeCoroutine = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBullet _))
        {
            _scoreCounter.Add(_scoreCounter.EnemyPoints);

            TriggerDeath();
        }
    }

    public void Init(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }

    private void TriggerDeath()
    {
        if (Dead != null)
        {
            Dead?.Invoke(this);

            Dead = null;
        }
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        TriggerDeath();
    }
}