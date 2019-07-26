using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPuzzleManager : MonoBehaviour
{
    public GameObject[] puzzleArray;
    public GameObject character;
    private List<PuzzleInterface> puzzles;
    private StateModel currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = DatabaseManager.Instance.CurrentState;
        foreach (GameObject puzzleGameObject in puzzleArray)
        {
            PuzzleInterface puzzle = puzzleGameObject.GetComponent<PuzzleInterface>();

            if (Int32.Parse(currentState.part) > Int32.Parse(puzzle.GetPart()) && Int32.Parse(currentState.level) > Int32.Parse(puzzle.GetLevel()))
            {
                puzzle.ChangeToEndState();
            }
            else
            {
                character.transform.position = puzzle.GetSpawnPosition();
                Vector3 rotation = puzzle.GetSpawnRotation();
                character.transform.rotation = new Quaternion(0f, rotation.y, 0f, 0f);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
