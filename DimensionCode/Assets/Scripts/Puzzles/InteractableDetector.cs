using System.Collections;
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if( currentInteractable != hit.transform)
            {
                ChangeToOriginalMaterial();
            }
   
            if ("Interactable" == hit.transform.tag)
            {
                currentInteractable = hit.transform;
                originalMaterial = currentInteractable.GetComponent<Renderer>().material;
                currentInteractable.GetComponent<Renderer>().material = interactableMaterial;
            }
        } else if (currentInteractable != null)
        {
            ChangeToOriginalMaterial();
        }
    }

    private void ChangeToOriginalMaterial()
    {
        if(currentInteractable != null){
            currentInteractable.GetComponent<Renderer>().material = originalMaterial;
            currentInteractable = null;
        }
    }
}
