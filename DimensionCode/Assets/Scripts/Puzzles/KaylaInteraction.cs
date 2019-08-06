using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaylaInteraction : MonoBehaviour, InteractableInterface
{
    [SerializeField]
    private EndDialogManager endScene;
    [SerializeField]
    private Camera firstCamera;
    [SerializeField]
    private Camera cutSceneCamera;


    public void Interact()
    {
        firstCamera.enabled = false;
        cutSceneCamera.enabled = true;
        endScene.StartEndscene();
        this.gameObject.tag = "Untagged";
    }
}
