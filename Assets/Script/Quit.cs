using UnityEngine;

public class ExitGameByKey : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        
        Application.Quit();
#endif
    }
}

