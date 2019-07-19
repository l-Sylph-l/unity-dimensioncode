using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPuzzle : MonoBehaviour, PuzzleInterface
{
    public Material liftMaterial;
    public LiftPlatform[] liftPlatformList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSpeedEqual();
    }

    // Checks if the speed of all Plattforms are equal.
    private bool CheckIfSpeedEqual()
    {
        float speedFromRecent = liftPlatformList[0].Speed;
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            if(speedFromRecent != liftPlatform.Speed)
            {
                return false;
            }
            speedFromRecent = liftPlatform.Speed;
        }
        return true;
    }

    private void ChangeLiftMaterial()
    {
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            liftPlatform.GetComponent<Renderer>().material = liftMaterial;
        }
    }

    public void ChangeToEndState()
    {

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
        return new Vector3(-4.88f, 11.4f, -0.61f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, 90f, 0f);
    }

}
