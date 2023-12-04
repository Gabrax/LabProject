using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(100);
            Debug.Log("coll");
        }
    }
}
