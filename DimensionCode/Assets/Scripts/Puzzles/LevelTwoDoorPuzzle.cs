using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoDoorPuzzle : MonoBehaviour, PuzzleInterface, InteractableInterface
{
    public GameObject door01Left, door01Right;
    public GameObject door02Left, door02Right;
    public GameObject door03Left, door03Right;
    public GameObject door04Left, door04Right;
    public GameObject door05Left, door05Right;
    public GameObject door06Left, door06Right;
    public GameObject door07Left, door07Right;
    public GameObject door08Left, door08Right;
    public GameObject door09Left, door09Right;
    public GameObject door10Left, door10Right;
    public GameObject door11Left, door11Right;
    public GameObject door12Left, door12Right;

    public GameObject doorButton;

    public float speed = 1.0f;

    private Transform target;

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
        return new Vector3(0f, 0.01f, 10.53f); // TODO: Level 2 Stats
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -237.921f, 0f); // TODO: Level 2 Stats
    }

    /**
    * End of Methods from the puzzle interface
    */

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        float step = speed * Time.deltaTime;
        target.transform.position = new Vector3(20f, 0f, 0f);

        // Prüfung für den Button Nr. 1
        if (doorButton.ToString() == "Geo_button")
        {
            this.gameObject.transform.parent.Rotate(new Vector3(0f, 90f, 0f));

            door02Left.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }       
    }
}
