using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayertimer;
    private float shotTimer;

    public override void Enter()
    {
        
    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {

            losePlayertimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            if(shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            enemy.transform.LookAt(enemy.Player.transform);
            if (moveTimer > Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.lastknownPosition = enemy.Player.transform.position;
        }
        else
        {
            losePlayertimer += Time.deltaTime;
            if(losePlayertimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * shootDirection * 40;
        shotTimer = 0;
    }
    public override void Exit()
    {

    }
}
