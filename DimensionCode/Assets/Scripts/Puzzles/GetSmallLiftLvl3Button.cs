using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSmallLiftLvl3Button : MonoBehaviour, InteractableInterface
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
