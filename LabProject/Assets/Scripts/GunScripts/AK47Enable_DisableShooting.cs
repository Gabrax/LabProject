using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AK47Enable_DisableShooting : MonoBehaviour
{

    private void Update()
    {
        Disable();
    }


    public GameObject Shoot;
    public TextMeshProUGUI magazineText;
    public void Enable()
    {
        Shoot.gameObject.SetActive(true);
    }

    public void Disable()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot.gameObject.SetActive(false);
            magazineText.gameObject.SetActive(false);
        }
            
    }
}
