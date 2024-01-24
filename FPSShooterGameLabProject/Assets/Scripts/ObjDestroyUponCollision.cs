using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjDestroyUponCollision : MonoBehaviour
{
    public Image imageToActivate;
    public GameObject objtodestruct;
    public AudioSource playSound;
    public TextMeshProUGUI TextToDeActivate;
    public TextMeshProUGUI TextToActivate;


     
    private void OnTriggerEnter(Collider other)
    {
            
            
             
            objtodestruct.gameObject.SetActive(false);
            playSound.Play();
            Debug.Log("Collision");
             
            imageToActivate.gameObject.SetActive(true);
            TextToActivate.gameObject.SetActive(true);
            TextToDeActivate.gameObject.SetActive(false);
            



    }
}

