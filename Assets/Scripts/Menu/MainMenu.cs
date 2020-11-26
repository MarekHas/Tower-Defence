using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
