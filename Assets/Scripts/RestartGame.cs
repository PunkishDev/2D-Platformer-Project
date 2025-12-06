using UnityEngine;

public class RestartGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadCurrentScene()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Main"); // loads to named scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // loads current scene
        Time.timeScale = 1; // unpauses game
    }
    
}
