using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteChangePuzzle : MonoBehaviour, PuzzleInterface
{
    public LiftPlatform[] liftPlatformList;
    private bool gameIsFocused = false;
    private bool puzzleFinished = false;


    // Update is called once per frame
    void Update()
    {
        if (!puzzleFinished)
        {
            CheckWebPuzzleState();
        }
    }

    public void CheckWebPuzzleState()
    {
        if (DatabaseManager.Instance.CurrentState.level.Equals("2") && gameIsFocused)
        {
            foreach (LiftPlatform liftPlatform in liftPlatformList)
            {
                liftPlatform.MoveToStopPosition = false;
                liftPlatform.MoveToEndPosition = true;
            }
            puzzleFinished = true;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        gameIsFocused = focus;
    }

    public void ChangeToEndState()
    {
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            Vector3 liftPosition = liftPlatform.transform.position;
            liftPlatform.MoveToEndPosition = true;
            liftPlatform.MoveToStopPosition = false;
            liftPlatform.transform.position = new Vector3(liftPosition.x, liftPlatform.endHeight, liftPosition.z);
        }
    }

    public string GetLevel()
    {
        return "1";
    }

    public string GetPart()
    {
        return "4";
    }

    public Vector3 GetSpawnPosition()
    {
        return new Vector3(0.7f, 7.5f, 0f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -90f, 0f);
    }

}
