using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    private Button[] _levelButtons;

    private void Start()
    {
        _levelButtons = GetComponentsInChildren<Button>();

        int levelWithHighestIndex = PlayerPrefs.GetInt(GameOverManager.LastLevelIndex, 0);

        for (int i = 0; i < levelWithHighestIndex + 1; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }

    public void LoadLevel(string name) => SceneManager.LoadScene(name);
}
