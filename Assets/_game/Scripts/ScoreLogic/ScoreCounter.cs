using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [field: SerializeField] public int EnemyPoints { get; private set; } = 100;
    [field: SerializeField] public int BottomZonePoints { get; private set; } = 1000;

    private int _value;

    public event Action<int> Updated;

    public void Add(int amount)
    {
        _value += amount;

        Updated?.Invoke(_value);
    }
}