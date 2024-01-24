using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LightFire : MonoBehaviour
{
    public Image matches;
    public Light firelight;
    private bool isOn = true;
    public ParticleSystem particle;

    public int maxCapacity = 10;
    private int currentCapacity;
    public TextMeshProUGUI matchesText;
    public AudioSource firesfx;
    

     
    void Start()
    {
        currentCapacity = maxCapacity;
        firelight.enabled = false;
        particle.Stop();
    }

     
    void Update()
    {
        if (currentCapacity <= 0)
        {
            matches.gameObject.SetActive(false);
            particle.Stop();
            firelight.enabled = false;
        }
        UpdatematchesText();
    }

    private void UpdatematchesText()
    {
        matchesText.text = $"{currentCapacity}/{maxCapacity}";
    }

    public void ToggleParticleSystem()
    {
        if (matches.gameObject.activeInHierarchy)
        {
            isOn = !isOn;
            

             
            if (isOn)
            {
                firelight.enabled = true;
                currentCapacity--;
                particle.Play();
                firesfx.Play();
            }
            else
            {
                firelight.enabled = false;
                particle.Stop();  
                firesfx.Stop();
            }
        }
        
    }
}
