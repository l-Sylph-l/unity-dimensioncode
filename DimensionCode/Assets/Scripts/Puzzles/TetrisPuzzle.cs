using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TetrisPuzzle : MonoBehaviour, PuzzleInterface
{
    // Um das Rätsel zu lösen muss das erste Tetriskonstrukt (Raum links unten) 2x gedreht werden, das mittlere Konstrukt 1x und das Letzte, direkt unter dem Bildschirmraum, muss 3x gedreht werden => 6891056.

    public TetrisTrigger rowTrigger01;
    public TetrisTrigger rowTrigger02;
    public TetrisTrigger rowTrigger03;
    public TetrisTrigger rowTrigger04;
    public TetrisTrigger rowTrigger05;
    public TetrisTrigger rowTrigger06;
    public TMP_Text displayText;

    bool tetrisPuzzleFinished = false;

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
        tetrisPuzzleFinished = true;
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
        //Debug.Log("rowTrigger01: " + rowTrigger01.getCount());
        //Debug.Log("rowTrigger02: " + rowTrigger02.getCount());
        //Debug.Log("rowTrigger03: " + rowTrigger03.getCount());
        //Debug.Log("rowTrigger04: " + rowTrigger04.getCount());
        //Debug.Log("rowTrigger05: " + rowTrigger05.getCount());
        //Debug.Log("rowTrigger06: " + rowTrigger06.getCount());

        string rowOne = rowTrigger01.getCount().ToString();
        string rowTwo = rowTrigger02.getCount().ToString();
        string rowThree = rowTrigger03.getCount().ToString();
        string rowFour = rowTrigger04.getCount().ToString();
        string rowFive = rowTrigger05.getCount().ToString();
        string rowSix = rowTrigger06.getCount().ToString();       

        if (rowOne == "6")
        {
            rowOne = ColorTextGreen(rowOne);
        }
        else
        {
            rowOne = ColorTextRed(rowOne);
        }

        if (rowTwo == "5")
        {
            rowTwo = ColorTextGreen(rowTwo);
        }
        else
        {
            rowTwo = ColorTextRed(rowTwo);
        }

        if (rowThree == "10")
        {
            rowThree = ColorTextGreen(rowThree);
        }
        else
        {
            rowThree = ColorTextRed(rowThree);
        }

        if (rowFour == "9")
        {
            rowFour = ColorTextGreen(rowFour);
        }
        else
        {
            rowFour = ColorTextRed(rowFour);
        }

        if (rowFive == "8")
        {
            rowFive = ColorTextGreen(rowFive);
        }
        else
        {
            rowFive = ColorTextRed(rowFive);
        }

        if (rowSix == "6")
        {
            rowSix = ColorTextGreen(rowSix);
        }
        else
        {
            rowSix = ColorTextRed(rowSix);
        }

        // Code beginnt bei 6, da rowOne(Collider) von rechts beginnt der Code aber normal von links her geschrieben werden muss.
        string tetrisCode = rowSix + rowFive + rowFour + rowThree + rowTwo + rowOne;

        displayText.text = tetrisCode;

        // Rätsel wurde gelöst
        if (tetrisCode == "6891056")
        {
            tetrisPuzzleFinished = true;
        }
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
