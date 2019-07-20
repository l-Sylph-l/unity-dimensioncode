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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(button01.IsActivated && button02.IsActivated && !puzzleFinished)
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
        Debug.Log("Button activated");
        DatabaseManager.Instance.UpdateState("1", "3");

        ShaderManager.Instance.LerpFloatProperty(doorMaterial, "_DisolveValue", 1.5f); 
        if(doorMaterial.GetFloat("_DisolveValue") > 1.45f)
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
