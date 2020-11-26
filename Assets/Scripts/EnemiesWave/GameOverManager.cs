using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel = null;
    [SerializeField] private GameObject _losePanel = null;

    private int _nextLevelIndex;

    public const string LastLevelIndex = "LastLevelIndex";

    private void OnEnable()
    {
        EnemiesWavesManager.OnPlayersWins += PlayerWinHandler;
        PlayerHealth.OnPlayerDefeat += PlayerLoseHandler;
    }

    private void OnDisable()
    {
        EnemiesWavesManager.OnPlayersWins -= PlayerWinHandler;
        PlayerHealth.OnPlayerDefeat -= PlayerLoseHandler;
    }

    private void PlayerWinHandler()
    {
        _winPanel.SetActive(true);

        string activeSceneName = SceneManager.GetActiveScene().name;
        string levelIndex = activeSceneName.Split('_')[2];
        int levelIndexValue = int.Parse(levelIndex);
        if (PlayerPrefs.GetInt(LastLevelIndex, 0) < levelIndexValue)
        {
            PlayerPrefs.SetInt(LastLevelIndex, levelIndexValue);
        }
        _nextLevelIndex = levelIndexValue + 1;
    }

    private void PlayerLoseHandler()
    {
        Time.timeScale = 0f;

        _losePanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        if (Application.CanStreamedLevelBeLoaded($"Scene_Level_{_nextLevelIndex}"))
        {
            SceneManager.LoadScene($"Scene_Level_{_nextLevelIndex}");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
