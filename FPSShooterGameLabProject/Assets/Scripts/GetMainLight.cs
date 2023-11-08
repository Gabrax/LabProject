using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainLight : MonoBehaviour
{
    [SerializeField]
    private Material skyboxmaterial;

    // Update is called once per frame
    void Update()
    {
        skyboxmaterial.SetVector(name = "_MainLight", transform.forward);
    }
}
