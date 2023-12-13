using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private GameObject options;

    private void Start() 
    {
        DisableButtonsDependingOnData();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DisableButtonsDependingOnData() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            loadGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked() 
    {
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }

    public void OnLoadGameClicked() 
    {
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }

    public void OnContinueGameClicked() 
    {
        DisableMenuButtons();
        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Level_1");
    }

    private void DisableMenuButtons() 
    {
        newGameButton.interactable = false;
        
    }

    public void ActivateMenu() 
    {
        this.gameObject.SetActive(true);
        DisableButtonsDependingOnData();
    }

    public void DeactivateMenu() 
    {
        this.gameObject.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetActive(true);
    }
    public void OptionsBack()
    {
        options.SetActive(false);
        ActivateMenu();
    }
}
