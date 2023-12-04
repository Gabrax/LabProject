using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerNextLevel1 : MonoBehaviour
{
    public AudioSource playSound;
    public AudioSource stopSound;
    public GameObject VictoryScreen;
    public GameObject pauseDestroy;


    void Start()
    {
        
    }

    public void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision");
            VictoryScreen.gameObject.SetActive(true);
            Destroy(pauseDestroy);
            stopSound.Stop();
            playSound.Play();
            Time.timeScale = 0f;
        }
        
    }
    



}
