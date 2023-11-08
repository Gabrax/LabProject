using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activate;
    public PatrolState patrol;

    public void Initialise()
    {
        patrol = new PatrolState();
        ChangeState(patrol);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
