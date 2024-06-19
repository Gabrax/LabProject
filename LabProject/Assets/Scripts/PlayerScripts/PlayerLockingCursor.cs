using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
     
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
