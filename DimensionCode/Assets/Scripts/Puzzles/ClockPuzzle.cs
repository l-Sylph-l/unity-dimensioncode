using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour, InteractableInterface, PuzzleInterface
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public Material correctMaterial;
    public Material failMaterial;
    public float rotationSpeedHour;
    public float rotationSpeedMinute;
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;
    private bool rotateHour = true;
    private bool rotateMinute = true;
    private bool minuteHandCorrect = false;
    private bool hourHandCorrect = false;
    private Material initialHourMaterial;
    private Material initialMinuteMaterial;
    private Vector3 openDoorPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialHourMaterial = hourHand.GetComponent<Renderer>().material;
        initialMinuteMaterial = minuteHand.GetComponent<Renderer>().material;
        openDoorPosition = this.transform.parent.position + new Vector3(3f, 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (minuteHandCorrect && hourHandCorrect)
        {
            // Open the clock door to the right.
            if (this.transform.parent.position.x < openDoorPosition.x)
            {
                ChangeToEndState();
                //this.transform.parent.Rotate(0, 0, 10f * Time.deltaTime);
            }
        }
        else
        {
            RotateHourHand();
            RotateMinuteHand();
        }
    }

    private int GetCurrentHour()
    {
        float result = GetCurrentHourAngle() / 30f;

        if (result == 0)
        {
            result = 12;
        }

        return (int)result;
    }

    private int GetCurrentMinute()
    {
        float result = GetCurrentMinuteAngle() / 6f;

        return (int)result;
    }

    private void CheckTime()
    {
        Debug.Log("Current Display Hour" + GetCurrentHour() + ", Current Real Hour: " + DateTime.Now.Hour);
        Debug.Log("Current Display Minute" + GetCurrentMinute() + ", Current Real Minute: " + DateTime.Now.Minute);
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;

        if (currentHour > 12)
        {
            currentHour = currentHour - 12;
        }

        if (!rotateMinute && (GetCurrentMinute() >= (currentMinute -1) && GetCurrentMinute() <= (currentMinute + 1)))
        {
            minuteHand.GetComponent<Renderer>().material = correctMaterial;
            minuteHandCorrect = true;
            rotateMinute = false;
        }
        else
        {
            rotateMinute = true;
            minuteHand.GetComponent<Renderer>().material = failMaterial;
        }


        if (!rotateMinute && !rotateHour && GetCurrentHour() == currentHour)
        {
            hourHand.GetComponent<Renderer>().material = correctMaterial;
            hourHandCorrect = true;
            rotateHour = false;
        }
        else
        {
            rotateHour = true;
            hourHand.GetComponent<Renderer>().material = failMaterial;
        }
    }

    private void RotateHourHand()
    {
        if (rotateHour)
        {
            if (rotateX)
            {
                hourHand.transform.Rotate(rotationSpeedHour * Time.deltaTime, 0, 0);
            }

            if (rotateY)
            {
                hourHand.transform.Rotate(0, rotationSpeedHour * Time.deltaTime, 0);
            }

            if (rotateZ)
            {
                hourHand.transform.Rotate(0, 0, rotationSpeedHour * Time.deltaTime);
            }
        }
    }

    private void RotateMinuteHand()
    {
        if (rotateMinute)
        {
            if (rotateX)
            {
                minuteHand.transform.Rotate(rotationSpeedMinute * Time.deltaTime, 0, 0);
            }

            if (rotateY)
            {
                minuteHand.transform.Rotate(0, rotationSpeedMinute * Time.deltaTime, 0);
            }

            if (rotateZ)
            {
                minuteHand.transform.Rotate(0, 0, rotationSpeedMinute * Time.deltaTime);
            }
        }
    }

    private float GetCurrentHourAngle()
    {
        if (rotateX)
        {
            return hourHand.transform.eulerAngles.x;
        }

        if (rotateY)
        {
            return hourHand.transform.eulerAngles.y;
        }

        if (rotateZ)
        {
            return hourHand.transform.eulerAngles.z;
        }

        return 0f;
    }

    private float GetCurrentMinuteAngle()
    {
        if (rotateX)
        {
            return minuteHand.transform.eulerAngles.x;
        }

        if (rotateY)
        {
            return minuteHand.transform.eulerAngles.y;
        }

        if (rotateZ)
        {
            return minuteHand.transform.eulerAngles.z;
        }

        return 0f;
    }

    public void Interact()
    {
        if (!rotateMinute && rotateHour)
        {
            rotateHour = false;
        }

        if (rotateMinute)
        {
            rotateMinute = false;
        }

        CheckTime();
    }

    public string GetPart()
    {
        return "1";
    }

    public string GetLevel()
    {
        return "1";
    }

    public void ChangeToEndState()
    {
        this.transform.parent.position = Vector3.Lerp(this.transform.parent.position, openDoorPosition, 0.6f * Time.deltaTime);
        minuteHand.GetComponent<Renderer>().material = correctMaterial;
        hourHand.GetComponent<Renderer>().material = correctMaterial;
        rotateMinute = false;
        minuteHandCorrect = true;
        hourHandCorrect = true;
    }
}
