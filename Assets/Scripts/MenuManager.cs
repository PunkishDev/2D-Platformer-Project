using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu, DeathMenu, LevelSelectMenu;

    private bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    private void PauseTime()
    {
        Time.timeScale = 0f;
    }
    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    //Menu Methods
    private void HideAllMenus()
    {
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
        LevelSelectMenu.SetActive(false);
    }
    public void Resume()
    {
        ResumeTime();
        HideAllMenus();
        paused = false;
    }
    public void Pause()
    {
        PauseTime();
        PauseMenu.SetActive(true);
        paused = true;
    }
    public void ShowLevelSelect()
    {
        LevelSelectMenu.SetActive(true);
    }
    public void HideLevelSelect()
    {
        LevelSelectMenu.SetActive(false);
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
    public void Quit()
    {
        Application.Quit();
    }

    //Level Select Method
    public void SelectLevel(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
}
