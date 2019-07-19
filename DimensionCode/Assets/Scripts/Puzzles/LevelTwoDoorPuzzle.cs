using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoDoorPuzzle : MonoBehaviour, PuzzleInterface
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

    bool door01Open = false;
    bool door02Open = false;
    bool door03Open = false;
    bool door04Open = false;
    bool door05Open = false;
    bool door06Open = false;
    bool door07Open = false;
    bool door08Open = false;
    bool door09Open = false;
    bool door10Open = false;
    bool door11Open = false;
    bool door12Open = false;
    bool allDoorsOpened = false;

    public GetDoorPuzzleButton doorButton02;
    public GetDoorPuzzleButton doorButton03;
    public GetDoorPuzzleButton doorButton04;
    public GetDoorPuzzleButton doorButton06;
    public GetDoorPuzzleButton doorButton08;
    public GetDoorPuzzleButton doorButton10;
    public GetDoorPuzzleButton doorButton11;
    public GetDoorPuzzleButton doorButton12;

    /**
    * Start of Methods from the puzzle interface
    */

    public string GetPart()
    {
        return "1"; // TODO: Check later!!
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
        return new Vector3(0.09f, 10.984f, 3.54f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -179.99f, 0f);
    }

    /**
    * End of Methods from the puzzle interface
    */

    // Wird benötigt, um die 3 Türen zu Beginn zu öffnen
    void Start()
    {
        // Türe 2 muss offen sein
        door02Left.transform.localPosition = new Vector3(-1.010432f, -3.45163f, 0.885674f);
        door02Right.transform.localPosition = new Vector3(-4.410432f, -3.45163f, 0.885674f);
        door02Open = true;
        // Türe 8 muss offen sein
        door08Left.transform.localPosition = new Vector3(-12.51043f, -3.45163f, -10.81433f);
        door08Right.transform.localPosition = new Vector3(-12.51043f, -3.45163f, - 7.414326f);
        door08Open = true;
        // Türe 10 muss offen sein
        door10Left.transform.localPosition = new Vector3(-1.010432f, -3.45163f, -12.31433f);
        door10Right.transform.localPosition = new Vector3(-4.410432f, -3.45163f, -12.31433f);
        door10Open = true;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonTriggered();
    }

    public void ButtonTriggered()
    {
        if (allDoorsOpened == false)
        { 
            // Prüfung für den Button Nr. 2
            if (doorButton02.buttonClick)
            {
                // Button Nr. 2 öffnet/schliesst die Türen 3 und 8
                if (door03Open == false)
                {
                    door03Left.transform.localPosition = door03Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door03Right.transform.localPosition = door03Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door03Open = true;
                }
                else if (door03Open == true)
                {
                    door03Left.transform.localPosition = door03Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door03Right.transform.localPosition = door03Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door03Open = false;
                }
                if (door08Open == false)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door08Open = true;
                }
                else if (door08Open == true)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door08Open = false;
                }
                doorButton02.buttonClick = false;
            }

            // Prüfung für den Button Nr. 3
            if (doorButton03.buttonClick)
            {
                // Button Nr. 3 öffnet/schliesst die Türen 2, 6 und 8
                if (door02Open == false)
                {
                    door02Left.transform.localPosition = door02Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door02Right.transform.localPosition = door02Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door02Open = true;
                }
                else if (door02Open == true)
                {
                    door02Left.transform.localPosition = door02Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door02Right.transform.localPosition = door02Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door02Open = false;
                }
                if (door06Open == false)
                {
                    door06Left.transform.localPosition = door06Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door06Right.transform.localPosition = door06Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door06Open = true;
                }
                else if (door06Open == true)
                {
                    door06Left.transform.localPosition = door06Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door06Right.transform.localPosition = door06Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door06Open = false;
                }
                if (door08Open == false)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door08Open = true;
                }
                else if (door08Open == true)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door08Open = false;
                }
                doorButton03.buttonClick = false;
            }

            // Prüfung für den Button Nr. 4
            if (doorButton04.buttonClick)
            {
                // Button Nr. 4 öffnet/schliesst die Türen 3 und 12
                if (door03Open == false)
                {
                    door03Left.transform.localPosition = door03Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door03Right.transform.localPosition = door03Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door03Open = true;
                }
                else if (door03Open == true)
                {
                    door03Left.transform.localPosition = door03Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door03Right.transform.localPosition = door03Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door03Open = false;
                }
                if (door12Open == false)
                {
                    door12Left.transform.localPosition = door12Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door12Right.transform.localPosition = door12Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door12Open = true;
                }
                else if (door12Open == true)
                {
                    door12Left.transform.localPosition = door12Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door12Right.transform.localPosition = door12Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door12Open = false;
                }
                doorButton04.buttonClick = false;
            }

            // Prüfung für den Button Nr. 6
            if (doorButton06.buttonClick)
            {
                // Button Nr. 6 öffnet/schliesst die Tür 6
                if (door06Open == false)
                {
                    door06Left.transform.localPosition = door06Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door06Right.transform.localPosition = door06Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door06Open = true;
                }
                else if (door06Open == true)
                {
                    door06Left.transform.localPosition = door06Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door06Right.transform.localPosition = door06Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door06Open = false;
                }
                doorButton06.buttonClick = false;
            }

            // Prüfung für den Button Nr. 8
            if (doorButton08.buttonClick)
            {
                // Button Nr. 8 öffnet/schliesst die Türen 10 und 11
                if (door10Open == false)
                {
                    door10Left.transform.localPosition = door10Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door10Right.transform.localPosition = door10Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door10Open = true;
                }
                else if (door10Open == true)
                {
                    door10Left.transform.localPosition = door10Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door10Right.transform.localPosition = door10Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door10Open = false;
                }
                if (door11Open == false)
                {
                    door11Left.transform.localPosition = door11Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door11Right.transform.localPosition = door11Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door11Open = true;
                }
                else if (door11Open == true)
                {
                    door11Left.transform.localPosition = door11Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door11Right.transform.localPosition = door11Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door11Open = false;
                }
                doorButton08.buttonClick = false;
            }

            // Prüfung für den Button Nr. 10
            if (doorButton10.buttonClick)
            {
                // Button Nr. 10 öffnet/schliesst die Tür 2
                if (door02Open == false)
                {
                    door02Left.transform.localPosition = door02Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door02Right.transform.localPosition = door02Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door02Open = true;
                }
                else if (door02Open == true)
                {
                    door02Left.transform.localPosition = door02Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door02Right.transform.localPosition = door02Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door02Open = false;
                }
                doorButton10.buttonClick = false;
            }

            // Prüfung für den Button Nr. 11
            if (doorButton11.buttonClick)
            {
                // Button Nr. 11 öffnet/schliesst die Türen 4, 8 und 10
                if (door04Open == false)
                {
                    door04Left.transform.localPosition = door04Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door04Right.transform.localPosition = door04Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door04Open = true;
                }
                else if (door04Open == true)
                {
                    door04Left.transform.localPosition = door04Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door04Right.transform.localPosition = door04Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door04Open = false;
                }
                if (door08Open == false)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door08Open = true;
                }
                else if (door08Open == true)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door08Open = false;
                }
                if (door10Open == false)
                {
                    door10Left.transform.localPosition = door10Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door10Right.transform.localPosition = door10Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door10Open = true;
                }
                else if (door10Open == true)
                {
                    door10Left.transform.localPosition = door10Left.transform.localPosition - new Vector3(0.7f, 0, 0);
                    door10Right.transform.localPosition = door10Right.transform.localPosition + new Vector3(0.7f, 0, 0);

                    door10Open = false;
                }
                doorButton11.buttonClick = false;
            }

            // Prüfung für den Button Nr. 12
            if (doorButton12.buttonClick)
            {
                // Button Nr. 12 öffnet alle Türen!
                if (door01Open == false)
                {
                    door01Left.transform.localPosition = door01Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door01Right.transform.localPosition = door01Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door01Open = true;
                }
                if (door02Open == false)
                {
                    door02Left.transform.localPosition = door02Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door02Right.transform.localPosition = door02Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door02Open = true;
                }
                if (door03Open == false)
                {
                    door03Left.transform.localPosition = door03Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door03Right.transform.localPosition = door03Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door03Open = true;
                }
                if (door04Open == false)
                {
                    door04Left.transform.localPosition = door04Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door04Right.transform.localPosition = door04Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door04Open = true;
                }
                if (door05Open == false)
                {
                    door05Left.transform.localPosition = door05Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door05Right.transform.localPosition = door05Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door05Open = true;
                }
                if (door06Open == false)
                {
                    door06Left.transform.localPosition = door06Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door06Right.transform.localPosition = door06Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door06Open = true;
                }
                if (door07Open == false)
                {
                    door07Left.transform.localPosition = door07Left.transform.localPosition + new Vector3(0, 0, 0.7f);
                    door07Right.transform.localPosition = door07Right.transform.localPosition - new Vector3(0, 0, 0.7f);

                    door07Open = true;
                }
                if (door08Open == false)
                {
                    door08Left.transform.localPosition = door08Left.transform.localPosition - new Vector3(0, 0, 0.7f);
                    door08Right.transform.localPosition = door08Right.transform.localPosition + new Vector3(0, 0, 0.7f);

                    door08Open = true;
                }
                if (door09Open == false)
                {
                    door09Left.transform.localPosition = door09Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door09Right.transform.localPosition = door09Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door09Open = true;
                }
                if (door10Open == false)
                {
                    door10Left.transform.localPosition = door10Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door10Right.transform.localPosition = door10Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door10Open = true;
                }
                if (door11Open == false)
                {
                    door11Left.transform.localPosition = door11Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door11Right.transform.localPosition = door11Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door11Open = true;
                }
                if (door12Open == false)
                {
                    door12Left.transform.localPosition = door12Left.transform.localPosition + new Vector3(0.7f, 0, 0);
                    door12Right.transform.localPosition = door12Right.transform.localPosition - new Vector3(0.7f, 0, 0);

                    door12Open = true;
                }

                // Alle Türen sind nun offen und dürfen nicht wieder geschlossen werden!
                allDoorsOpened = true;
            }
        }
    }
}

