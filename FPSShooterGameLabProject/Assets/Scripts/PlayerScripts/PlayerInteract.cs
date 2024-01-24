using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3.0f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
     
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

     
    void Update()
    {
         
        playerUI.UpdateText(string.Empty);
         
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;  
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
             
            if(hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.Walk.Interact.triggered)
                {
                    interactable.BaseInteract();
                }

            }
        }
    }
}
