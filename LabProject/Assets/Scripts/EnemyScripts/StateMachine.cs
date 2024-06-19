using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activate;
    

    public void Initialise()
    {
        ChangeState(new PatrolState());
    }
     
    void Start()
    {
        
    }

     
    void Update()
    {
        if (activate != null) 
        {
            activate.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        if (activate != null)
        {
            activate.Exit();
        }
        activate = newState;

        if (activate != null) 
        {
            activate.stateMachine = this;
            activate.enemy = GetComponent<Enemy>();
            activate.Enter();
        }
    }
}
