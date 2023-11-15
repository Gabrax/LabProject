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
    

    // Start is called before the first frame update
    void Start()
    {
        currentCapacity = maxCapacity;
        firelight.enabled = false;
        particle.Stop();
    }

    // Update is called once per frame
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
            

            // Perform specific behavior based on isOn
            if (isOn)
            {
                firelight.enabled = true;
                currentCapacity--;
                particle.Play();
            }
            else
            {
                firelight.enabled = false;
                particle.Stop(); // Do something when it's off
            }
        }
        
    }
}
