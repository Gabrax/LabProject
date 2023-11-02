using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnlockMouseUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UnlockMouseUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadLevel(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
