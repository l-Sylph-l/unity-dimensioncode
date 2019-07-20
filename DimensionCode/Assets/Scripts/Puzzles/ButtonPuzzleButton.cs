using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleButton : MonoBehaviour, InteractableInterface
{
    public bool IsActivated { get; set; } = false;
    public Material activatedMaterial;

    private Material[] materials;

    public void Interact()
    {
        if(DatabaseManager.Instance.CurrentState.part == "2")
        {
            IsActivated = true;
            this.gameObject.GetComponent<Renderer>().materials[0] = activatedMaterial;
        }
    }
}
