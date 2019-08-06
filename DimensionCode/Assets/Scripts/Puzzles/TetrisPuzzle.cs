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
    public GameObject elevatorToLvl3;

    bool elevatorDown = true;
    bool tetrisPuzzleFinished = false;
    float secondsToWait = 4f;

    /**
     * Start of Methods from the puzzle interface
     */

    public string GetPart()
    {
        return "2";
    }

    public string GetLevel()
    {
        return "2";
    }

    public void ChangeToEndState()
    {
        if (DatabaseManager.Instance.CurrentState.level == GetLevel() && DatabaseManager.Instance.CurrentState.part == GetPart())
        {
            DatabaseManager.Instance.UpdateState("3", "1");
        }
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

        string tetrisCode = rowSix + rowFive + rowFour + rowThree + rowTwo + rowOne;

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
        string formattedTetrisCode = rowSix + rowFive + rowFour + rowThree + rowTwo + rowOne;

        displayText.text = formattedTetrisCode;

        // Rätsel wurde gelöst
        if (tetrisCode == "6891056")
        {
            ChangeToEndState();
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

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
    }

    void Update()
    {
        DisplayCurrentValue();

        // Lift wird aktiviert
        if (tetrisPuzzleFinished == true)
        {
            Vector3 start = new Vector3(9.89f, 10.17f, -10.02f);
            Vector3 target = new Vector3(9.89f, 14.06f, -10.02f);

            if (elevatorDown == true)
            {
                float step = 2f * Time.deltaTime;
                elevatorToLvl3.transform.position = Vector3.MoveTowards(elevatorToLvl3.transform.position, target, step);
                //StartCoroutine(waiter());               
            }

            if (elevatorDown == false)
            {
                float step = 2f * Time.deltaTime;
                elevatorToLvl3.transform.position = Vector3.MoveTowards(elevatorToLvl3.transform.position, start, step);
                //StartCoroutine(waiter());
            }

            if ((elevatorToLvl3.transform.position == target) && (elevatorDown == true))
            {
                secondsToWait -= Time.deltaTime;
                if (secondsToWait < 0f)
                {
                    elevatorDown = false;
                    secondsToWait = 4f;
                }
            }

            if ((elevatorToLvl3.transform.position == start) && (elevatorDown == false))
            {
                secondsToWait -= Time.deltaTime;
                if (secondsToWait < 0f)
                {
                    elevatorDown = true;
                    secondsToWait = 4f;
                }
            }
        }
    }
}
