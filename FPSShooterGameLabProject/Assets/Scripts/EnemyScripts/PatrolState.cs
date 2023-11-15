using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointindex;
    public override void Enter()
    {
    }
    public override void Perform()
    {
        PatrolCycle();
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            if(waypointindex < enemy.path.waypoints.Count - 1) 
            {
                waypointindex++;
            }
            else
                waypointindex = 0;
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointindex].position);
        }
    }
}
