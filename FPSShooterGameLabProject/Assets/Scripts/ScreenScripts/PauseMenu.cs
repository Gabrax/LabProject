using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused;
    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(isPaused == true) 
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }

        if (PauseMenuCanvas.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            Cursor.visible = true;
        }
            
    }
    public void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            Cursor.visible = false;
        }
            
    }
    public void ResumeGameButton()
    {
            PauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            Cursor.visible = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
