using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreKeeper;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scoreKeeper.Updated += Updated;
    }

    private void OnDisable()
    {
        _scoreKeeper.Updated -= Updated;
    }

    private void Updated(int score)
    {
        _text.text = $"Score: {score}";
    }
}