using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu, DeathMenu, LevelSelectMenu;

    private void PauseTime()
    {
        Time.timeScale = 0f;
    }
    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    //Menu Methods
    public void Resume()
    {
        ResumeTime();
        PauseMenu.SetActive(false);
    }
    public void Pause()
    {
        PauseTime();
        PauseMenu.SetActive(true);
    }
    public void Die()
    {
        PauseTime();
        DeathMenu.SetActive(true);
    }
    public void Respawn()
    {
        ResumeTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
