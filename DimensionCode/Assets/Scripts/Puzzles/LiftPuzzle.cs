using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPuzzle : MonoBehaviour, PuzzleInterface
{

    public Material hologramMaterial;
    public LiftPlatform[] liftPlatformList;
    public GameObject character;
    public GameObject collider;
    private Material[] initialLiftMaterial;
    private bool puzzleFinished = false;
    private bool gameIsFocused = true;

    // Start is called before the first frame update
    void Start()
    {
        Material[] hologramMaterials = { hologramMaterial, hologramMaterial };
        initialLiftMaterial = liftPlatformList[1].GetComponent<Renderer>().materials;
        ChangeLiftMaterial(hologramMaterials);
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleFinished)
        {
            CheckIfSpeedEqual();
            CheckIfCharacterIsOnLift();
            CheckWebPuzzleState();
        }
    }

    // Checks if the speed of all Plattforms are equal.
    private bool CheckIfSpeedEqual()
    {
        float speedFromRecent = liftPlatformList[0].Speed;
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            if (speedFromRecent != liftPlatform.Speed)
            {
                return false;
            }
            speedFromRecent = liftPlatform.Speed;
        }

        ActivateCollider();
        ChangeLiftMaterial(initialLiftMaterial);
        return true;
    }

    private bool CheckIfCharacterIsOnLift()
    {
        if (character.transform.position.y > 7.9)
        {
            foreach (LiftPlatform liftPlatform in liftPlatformList)
            {
                liftPlatform.MoveToStopPosition = true;                
            }
            DatabaseManager.Instance.UpdateState("1", "4");
            return true;
        }

        return false;
    }

    private void ActivateCollider()
    {
        collider.GetComponent<MeshCollider>().enabled = true;
    }

    private void ChangeLiftMaterial(Material[] inMaterials)
    {
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            liftPlatform.GetComponent<Renderer>().materials = inMaterials;
        }
    }

    public void CheckWebPuzzleState()
    {
        Debug.Log("Current Level (Lift): " + DatabaseManager.Instance.CurrentState.level);
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

    public void ChangeToEndState()
    {
        foreach (LiftPlatform liftPlatform in liftPlatformList)
        {
            Vector3 liftPosition = liftPlatform.transform.position;
            liftPlatform.GetComponent<Renderer>().materials = initialLiftMaterial;
            liftPlatform.MoveToEndPosition = true;
            liftPlatform.MoveToStopPosition = true;
            liftPlatform.transform.position = new Vector3(liftPosition.x, liftPlatform.endHeight, liftPosition.z);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        gameIsFocused = focus;
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
