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
            other.GetComponent<PlayerHealth>().Heal(100);
            Destroy(aid);
            Debug.Log("coll");
        }
    }
    
}
