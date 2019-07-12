using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTetrisBlock : MonoBehaviour, InteractableInterface
{
    /**
 * Start of Methods from the interact interface
 * IMPORTANT: This Gameobject must have the Tag "Interactable"
 */

    public void Interact()
    {
        this.gameObject.transform.parent.Rotate(new Vector3(0f, 90f, 0f));
    }
}
