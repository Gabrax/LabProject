using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerNextLevel : MonoBehaviour
{
    public TextMeshProUGUI TextToActivate;
    public Image Key;
    public AudioSource playSound;
    public AudioSource stopSound;
    public GameObject VictoryScreen;
    public GameObject pauseDestroy;
    public GameObject ak47;
    public GameObject m16;


    void Start()
    {
        
    }

    public void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");

        if(Key.gameObject.activeInHierarchy)
        {
            VictoryScreen.gameObject.SetActive(true);
            TextToActivate.gameObject.SetActive(false);
            Destroy(pauseDestroy);
            ak47.gameObject.SetActive(false);
            m16.gameObject.SetActive(false);
            stopSound.Stop();
            playSound.Play();
            Time.timeScale = 0f;
        }
        else
        {
            TextToActivate.gameObject.SetActive(true);
        }
        
    }
    



}
