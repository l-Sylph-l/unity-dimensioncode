using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TetrisPuzzle : MonoBehaviour, PuzzleInterface
{
    public TetrisTrigger rowTrigger01;
    public TetrisTrigger rowTrigger02;
    public TetrisTrigger rowTrigger03;
    public TetrisTrigger rowTrigger04;
    public TetrisTrigger rowTrigger05;
    public TetrisTrigger rowTrigger06;
    public TMP_Text displayText;

    /**
     * Start of Methods from the puzzle interface
     */

    public string GetPart()
    {
        return "2"; // TODO: Check later!!
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
        return new Vector3(0.09f, 10.984f, 3.54f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -179.99f, 0f);
    }

    /**
    * End of Methods from the puzzle interface
    */

    void DisplayCurrentValue()
    {
        Debug.Log("rowTrigger01: " + rowTrigger01.getCount());
        Debug.Log("rowTrigger02: " + rowTrigger02.getCount());
        Debug.Log("rowTrigger03: " + rowTrigger03.getCount());
        Debug.Log("rowTrigger04: " + rowTrigger04.getCount());
        Debug.Log("rowTrigger05: " + rowTrigger05.getCount());
        Debug.Log("rowTrigger06: " + rowTrigger06.getCount());

        string rowOne = rowTrigger01.getCount().ToString();
        string rowTwo = rowTrigger02.getCount().ToString();
        string rowThree = rowTrigger03.getCount().ToString();
        string rowFour = rowTrigger04.getCount().ToString();
        string rowFive = rowTrigger05.getCount().ToString();
        string rowSix = rowTrigger06.getCount().ToString();

        // Code beginnt bei 6, da rowOne(Collider) von rechts beginnt der Code aber normal von links her geschrieben werden muss.
        string tetrisCode = ColorTextRed(rowSix) + ColorTextGreen(rowFive) + ColorTextRed(rowFour) + ColorTextGreen(rowThree) + ColorTextGreen(rowTwo) + ColorTextRed(rowOne);

        displayText.text = tetrisCode;
    }

    string ColorTextRed(string value)
    {
        return "<color=red>" + value + "</color>";
    }

    string ColorTextGreen(string value)
    {
        return "<color=green>" + value + "</color>";
    }

    void Update()
    {
        DisplayCurrentValue();
    }
}
