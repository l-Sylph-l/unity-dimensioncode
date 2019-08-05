using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Terminal : MonoBehaviour, InteractableInterface
{
    public GameObject prison;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (true)
        {
            ShaderManager.Instance.LerpFloatProperty(prison.GetComponent<Renderer>().material, "_DisolveValue", 1.5f);
            ShaderManager.Instance.LerpOpacityProperty(prison.GetComponent<Renderer>().material, "_BaseColor", 0f);

            if (prison.GetComponent<Renderer>().material.GetFloat("_DisolveValue") > 1.4f)
            {
                prison.GetComponent<BoxCollider>().enabled = false;
                DestroyImmediate(prison);
            }
        }
    }
}
