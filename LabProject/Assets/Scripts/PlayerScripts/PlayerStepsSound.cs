using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource sprintSound;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                footstepsSound.pitch = 0.5f;
                sprintSound.enabled = true;
                sprintSound.pitch = 0.5f;
            }
            else
            {
                footstepsSound.enabled = true;
                footstepsSound.pitch = 0.5f;
                sprintSound.enabled = false;
                sprintSound.pitch = 0.5f;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            footstepsSound.pitch = 0.5f;
            sprintSound.enabled = false;
            sprintSound.pitch = 0.5f;
        }
    }
}