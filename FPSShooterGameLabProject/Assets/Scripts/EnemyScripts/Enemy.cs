using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    private StateMachine m_Machine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastknowPosition;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 lastknownPosition { get => lastknowPosition; set => lastknowPosition = value; }
    

    [Header("SightValues")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyesight;
    [Header("Weapon")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]
    public float fireRate;
    [SerializeField]
    private string currentState;
    public Path path;
    
    


    // Start is called before the first frame update
    void Start()
    {
        m_Machine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        m_Machine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = m_Machine.activate.ToString();
        
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyesight);
                float angleToplayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToplayer >= -fieldOfView && angleToplayer <= fieldOfView) 
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyesight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        
                        if (hitInfo.transform.gameObject == player)
                            {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                                
                            }
                        
                    }
                    
                }

            }
        }
        return false;
    }
}
