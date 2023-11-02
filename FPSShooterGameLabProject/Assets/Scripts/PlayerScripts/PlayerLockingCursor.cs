using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    // Set this variable to true to lock the cursor on scene load
    public bool lockCursorOnLoad = true;

    void Start()
    {
        if (lockCursorOnLoad)
        {
            LockAndHideCursor();
        }
    }

    void Update()
    {
        // You can use a key press to toggle cursor lock during gameplay
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                UnlockAndShowCursor();
            }
            else
            {
                LockAndHideCursor();
            }
        }
    }

    void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockAndShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
