using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoorPuzzleButton : MonoBehaviour, InteractableInterface
{
    bool buttonClicked = false;

    public bool buttonClick
    {
        get { return buttonClicked; }
        set { buttonClicked = value; }
    }

    public void Interact()
    {
        buttonClicked = true;
    }
}
