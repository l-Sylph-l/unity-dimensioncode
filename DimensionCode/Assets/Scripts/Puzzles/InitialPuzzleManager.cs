using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPuzzleManager : MonoBehaviour
{
    public GameObject[] puzzleArray;
    public DatabaseManager dbManager;
    public GameObject character;
    private List<PuzzleInterface> puzzles;
    private StateModel currentState;

    // Start is called before the first frame update
    void Start()
    {
        dbManager.ReadState().ContinueWith(dbTask =>
         {
             Debug.Log("Loading states...");
             if (dbTask.IsFaulted)
             {
                 Debug.Log("Error reading states: " + dbTask.Result);
             }
             else if (dbTask.IsCompleted)
             {
                 Debug.Log("Loaded states");
                 DataSnapshot snapshot = dbTask.Result;
                 StateModel currentState = dbManager.JsonToObject(snapshot.GetRawJsonValue());
                 foreach (GameObject gameobject in puzzleArray)
                 {
                     PuzzleInterface puzzle = gameObject.GetComponent<PuzzleInterface>();

                     if(Int32.Parse(currentState.part)  > Int32.Parse(puzzle.GetPart()))
                     {
                         puzzle.ChangeToEndState();
                     } else
                     {
                         character.transform.position = puzzle.GetSpawnPosition();
                         Vector3 rotation = puzzle.GetSpawnRotation();
                         character.transform.rotation = new Quaternion(0f, rotation.y, 0f, 0f); 
                     }
                 }
             }     
         });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
