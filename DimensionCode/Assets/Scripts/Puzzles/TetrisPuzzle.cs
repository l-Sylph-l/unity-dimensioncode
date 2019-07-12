using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPuzzle : MonoBehaviour, PuzzleInterface
{
    public TetrisTrigger rowTrigger01;
    public TetrisTrigger rowTrigger02;
    public TetrisTrigger rowTrigger03;
    public TetrisTrigger rowTrigger04;
    public TetrisTrigger rowTrigger05;
    public TetrisTrigger rowTrigger06;

    /**
     * Start of Methods from the puzzle interface
     */

    public string GetPart()
    {
        return "4"; // TODO: Check later!!
    }

    public string GetLevel()
    {
        return "2";
    }

    public void ChangeToEndState()
    {
        return;
    }

    public Vector3 GetSpawnPosition()
    {
        return new Vector3(0f, 0.01f, 10.53f); // TODO: Level 2 Stats
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -237.921f, 0f); // TODO: Level 2 Stats
    }

    /**
    * End of Methods from the puzzle interface
    */

    string GetCurrentValue()
    {
        Debug.Log("rowTrigger01: " + rowTrigger01.getCount());
        return null;
    }

    void Update()
    {
        GetCurrentValue();
    }
}
