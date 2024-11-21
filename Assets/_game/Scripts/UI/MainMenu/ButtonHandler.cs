using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private const string GameSceneName = "Game";

    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _start.onClick.AddListener(LoadScene);
        _exit.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(LoadScene);
        _exit.onClick.RemoveListener(QuitGame);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}