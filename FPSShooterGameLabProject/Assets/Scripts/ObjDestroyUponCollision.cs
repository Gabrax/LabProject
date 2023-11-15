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


    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            playSound.Play();
            // Destroy the object that has collided with this script
            collision.gameObject.SetActive(false);

            // Activate the image
            if (imageToActivate != null)
            {
                imageToActivate.gameObject.SetActive(true);
            }
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
            
            
            // Destroy the object that has collided with this script
            objtodestruct.gameObject.SetActive(false);
            playSound.Play();
            Debug.Log("Collision");
            // Activate the image
            imageToActivate.gameObject.SetActive(true);
            TextToActivate.gameObject.SetActive(true);
            TextToDeActivate.gameObject.SetActive(false);
            



    }
}

