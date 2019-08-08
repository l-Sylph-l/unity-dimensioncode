using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleButton : MonoBehaviour, InteractableInterface
{
    public bool IsActivated { get; set; } = false;
    public Material activatedMaterial;
    [SerializeField]
    private GameObject visualEffect;
    [SerializeField]
    private ButtonPuzzleButton dependendButton;

    private Material[] materials;

    public void Interact()
    {
        if (DatabaseManager.Instance.CurrentState.part == "2")
        {
            IsActivated = true;
            this.gameObject.GetComponent<Renderer>().materials[0] = activatedMaterial;

            if (dependendButton.IsActivated)
            {
                visualEffect.SetActive(true);
            }
        }
    }
}
