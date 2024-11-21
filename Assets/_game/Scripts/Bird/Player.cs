using System;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreKeeper;

    private PlayerCollisionHandler _playerDetector;

    public event Action GameEnded;

    private void Awake()
    {
        _playerDetector = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _playerDetector.Collided += ProcessCollision;
    }

    private void OnDisable()
    {
        _playerDetector.Collided -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground || interactable is Bullet)
        {
            GameOver();
        }
        else if (interactable is BigScoreTrigger)
        {
            _scoreKeeper.Add(_scoreKeeper.BottomZonePoints);
        }
    }

    private void GameOver()
    {
        GameEnded?.Invoke();

        Time.timeScale = 0;
    }
}