using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealOnColl : MonoBehaviour
{
    public GameObject aid;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth HP = other.GetComponent<PlayerHealth>();

            if (HP != null && HP.health < HP.maxHealth)
            {
                other.GetComponent<PlayerHealth>().Heal(100);
                Destroy(aid);
                Debug.Log("coll");
            }
                
        }
    }
    
}
