﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    public Material interactableMaterial;
    private Material originalMaterial;
    private Transform currentInteractable;

    // Update is called once per frame
    void Update()
    {
        ChangeToOriginalMaterial();
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < 3f)
            {
                Debug.Log(hit.transform.name);
                if (currentInteractable != hit.transform)
                {
                    ChangeToOriginalMaterial();
                }

                if ("Interactable" == hit.transform.tag)
                {
                    ActivateInteractable(hit);
                }
                else if ("InteractableChild" == hit.transform.tag)
                {
                    ActivateInteractableChild(hit);
                }
            }
        }
        else if (currentInteractable != null)
        {
            ChangeToOriginalMaterial();
        }
    }

    private void ChangeToOriginalMaterial()
    {
        if (currentInteractable != null && currentInteractable.tag == "InteractableChild")
        {
            foreach (Transform child in currentInteractable.parent)
            {
                child.GetComponent<Renderer>().material = originalMaterial;
            }
        }

        if (currentInteractable != null)
        {
            currentInteractable.GetComponent<Renderer>().material = originalMaterial;
            currentInteractable = null;
        }
    }

    private void ActivateInteractable(RaycastHit hit)
    {
        currentInteractable = hit.transform;
        originalMaterial = currentInteractable.GetComponent<Renderer>().material;
        currentInteractable.GetComponent<Renderer>().material = interactableMaterial;
        InteractableInterface action = currentInteractable.GetComponent<InteractableInterface>();


        if (Input.GetMouseButtonDown(0))
        {
            action.Interact();
        }
    }

    private void ActivateInteractableChild(RaycastHit hit)
    {
        ActivateInteractable(hit);

        foreach (Transform child in currentInteractable.parent)
        {
            child.GetComponent<Renderer>().material = interactableMaterial;
        }
    }
}
