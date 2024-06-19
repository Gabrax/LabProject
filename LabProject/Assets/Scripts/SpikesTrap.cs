using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrap : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;
    public AudioSource spikes;
    public AudioSource reversespikes;
     
    void Start()
    {
        
    }

    
     
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Transform hitTransform = other.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("spikes");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(25);
            
        }
        if(other.CompareTag("Player"))
        { 
            animator.SetBool("IsTrigger", true);
            spikes.Play();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsTrigger", false);
            reversespikes.Play();
        }
    }
}
