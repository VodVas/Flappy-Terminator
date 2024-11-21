using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _buttonRestart.gameObject.SetActive(false);
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        _player.GameEnded += StartEndGameScreen;
        _buttonRestart.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _player.GameEnded -= StartEndGameScreen;
        _buttonRestart.onClick.RemoveListener(RestartGame);
    }

    private void StartEndGameScreen()
    {
        _panel.SetActive(true);
        _buttonRestart.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        ReloadCurrentScene();
    }

    public void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        Time.timeScale = 1;

        SceneManager.LoadScene(currentSceneName);
    }
}