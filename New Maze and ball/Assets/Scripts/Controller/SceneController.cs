using UnityEngine;
using UnityEngine.SceneManagement;


namespace NewMazeAndBall
{
    internal sealed class SceneController
    {
        internal void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }
    }
}
