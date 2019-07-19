using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour, PuzzleInterface, InteractableInterface
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * Start of Methods from the interact interface
    * IMPORTANT: This Gameobject must have the Tag "Interactable"
    */
    public void Interact()
    {
        ChangeToEndState();
    }

    /**
    * Start of Methods from the puzzle interface
    */

    public string GetPart()
    {
        return "2";
    }

    public string GetLevel()
    {
        return "1";
    }

    public void ChangeToEndState()
    {
        Debug.Log("Button activated");
        DatabaseManager.Instance.UpdateState("1", "2");
    }

    public Vector3 GetSpawnPosition()
    {
        return new Vector3(0f, 0.01f, 5.87f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -177.584f, 0f);
    }

    /**
    * End of Methods from the puzzle interface
    */
}
