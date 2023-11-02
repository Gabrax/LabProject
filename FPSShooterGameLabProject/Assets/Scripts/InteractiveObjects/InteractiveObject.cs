using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function is responsible for interaction design of a interactive object
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
