using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoors : MonoBehaviour
{
    public Image Key;
    public GameObject button;
    public GameObject door;
    private bool doorOpen;
    public TextMeshProUGUI TextToActivate;
    public AudioSource buttonSound;

     
    void Start()
    {
        
    }

     
    void Update()
    {
        
    }

    public void Open()
    {
        if (Key.gameObject.activeInHierarchy)
        {
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
            TextToActivate.gameObject.SetActive(false);

        }
        else
        {
            TextToActivate.gameObject.SetActive(true);
        }
    }
    public void TouchButton()
    {
        buttonSound.Play();
    }
    
}
