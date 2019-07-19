using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonFunction { Faster, Slower };

public class LiftButton : MonoBehaviour, InteractableInterface
{
    public LiftPlatform platform;
 
    public ButtonFunction buttonFunction;

    public void Interact()
    {
        platform.ChangeSpeed(buttonFunction);
    }

}
