using UnityEngine;
using UnityEngine.UI;

public class ObjectsActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Enable);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Enable);
    }

    private void Enable()
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}