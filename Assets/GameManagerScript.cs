using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource musicAudioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PauseMusic()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.Pause();
        }
    }
 public void gameOver()
{
    gameOverUI.SetActive(true);
    Time.timeScale = 0f;
     PauseMusic();
}

public void restart() 
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

public void mainMenu()
{
    SceneManager.LoadScene("Menu");
}

public void quit()
{
    Application.Quit();
}
}
