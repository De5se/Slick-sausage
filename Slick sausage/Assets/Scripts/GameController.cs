using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject WinPanel;

    private void Start()
    {
        Time.timeScale = 0.000001f;
    }
    public void LooseGame()
    {
        Time.timeScale = 0.000001f;
        LoosePanel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void Play()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0.000001f;
    }
}
