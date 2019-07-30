using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour, PuzzleInterface
{
    public ButtonPuzzleButton button01;
    public ButtonPuzzleButton button02;
    public Material doorMaterial;
    public GameObject[] doors;
    public GameObject[] lasers;

    private bool puzzleFinished = false;
    private StateModel initialState;

    // Start is called before the first frame update
    void Start()
    {
        doorMaterial.SetFloat("_DisolveValue", -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (button01.IsActivated && button02.IsActivated && !puzzleFinished)
        {
            ChangeToEndState();
        }
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
        if (DatabaseManager.Instance.CurrentState.level == GetLevel() && DatabaseManager.Instance.CurrentState.part == GetPart())
        {
            DatabaseManager.Instance.UpdateState("1", "3");
        }

        if(initialState == null)
        {
            initialState = DatabaseManager.Instance.CurrentState;
        }

        if (int.Parse(initialState.level) <= int.Parse(GetLevel()) && int.Parse(initialState.part) <= int.Parse(GetPart()))
        {
            ShaderManager.Instance.LerpFloatProperty(doorMaterial, "_DisolveValue", 1.5f);
            if (doorMaterial.GetFloat("_DisolveValue") > 1.45f)
            {
                foreach (GameObject door in doors)
                {
                    Destroy(door);
                }

                foreach (GameObject laser in lasers)
                {
                    Destroy(laser);
                }

                puzzleFinished = true;
            }
        }
        else
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }

            foreach (GameObject laser in lasers)
            {
                Destroy(laser);
            }
        }


    }

    public Vector3 GetSpawnPosition()
    {
        return new Vector3(4.07f, 0.01f, 9.36f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -231.901f, 0f);
    }

    /**
    * End of Methods from the puzzle interface
    */
}
