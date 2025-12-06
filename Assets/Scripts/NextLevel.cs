using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public string nextLvlName;
    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLvlName); // loads to named scene
        Time.timeScale = 1; // unpauses game

        // make sure the next level is in the shared scene build list
    }
}
