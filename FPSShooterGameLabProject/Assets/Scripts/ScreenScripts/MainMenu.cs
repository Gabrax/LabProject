using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{



    [SerializeField] private Button Play;
    [SerializeField] private Button Load;
    [SerializeField] private Button Options;
    [SerializeField] private Button Quit;
    [SerializeField] private SaveSlotsMenu saveSlots;

    private void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            Load.interactable = false;
            
        }
    }
    public void PlayGame()
    {

        saveSlots.ActivateMenu(false);
        this.DeactivateMenu();
    }

    public void OnLoadGameclicked()
    {
        saveSlots.ActivateMenu(true);
        this.DeactivateMenu();
    }
    public void LoadGame()
    {
        
        SceneManager.LoadSceneAsync("Level_1");
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        Play.interactable = false;
        Load.interactable = false;
        Options.interactable = false;
        Quit.interactable = false;

    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
