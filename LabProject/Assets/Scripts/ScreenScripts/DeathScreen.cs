using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource deathsound;
    public AudioSource stopsound;
    public GameObject ak47;
    public GameObject m16;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

     
    void Update()
    {
        
        if(gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.gameObject.SetActive(true);
        deathsound.Play();
        stopsound.Stop();
        Destroy(ak47);
        Destroy(m16);
        
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
