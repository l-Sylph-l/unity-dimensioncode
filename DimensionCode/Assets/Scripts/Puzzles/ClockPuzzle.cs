﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour, PuzzleInterface, InteractableInterface
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
        float result = (GetCurrentHourAngle() ) / 30f ;
        int convertedResult = (int)result;

        if (convertedResult == 0)
        {
            convertedResult = 12;
        }

        return convertedResult;
    }

    private int GetCurrentMinute()
    {
        float result = GetCurrentMinuteAngle() / 6f;

        return (int)result;
    }

    private void CheckMinuteTime()
    {
        int currentMinute = DateTime.Now.Minute;

        if (rotateMinute && IsMinuteValid(currentMinute))
        {
            minuteHand.GetComponent<Renderer>().material = correctMaterial;
            minuteHandCorrect = true;
            rotateMinute = false;
        }
        else
        {
            rotateHour = true;
            rotateMinute = true;
            minuteHand.GetComponent<Renderer>().material = failMaterial;
        }
    }

    private void CheckHourTime()
    {
        int currentHour = DateTime.Now.Hour;

        if (currentHour > 12)
        {
            currentHour = currentHour - 12;
        }

        if (rotateHour && GetCurrentHour() == currentHour)
        {
            hourHand.GetComponent<Renderer>().material = correctMaterial;
            hourHandCorrect = true;
            rotateHour = false;
        }
        else
        {
            rotateHour = true;
            rotateMinute = true;
            hourHand.GetComponent<Renderer>().material = failMaterial;
            minuteHand.GetComponent<Renderer>().material = failMaterial;
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


    private bool IsMinuteValid(int currentMinute)
    {
        int lowestMinute = currentMinute - 2;
        int highestMinute = currentMinute + 2;
        return (GetCurrentMinute() >= lowestMinute && GetCurrentMinute() <= highestMinute);
    }

    /**
     * Start of Methods from the interact interface
     * IMPORTANT: This Gameobject must have the Tag "Interactable"
     */
    public void Interact()
    {
        if (rotateMinute)
        {
            CheckMinuteTime();
        } else
        {
            CheckHourTime();
        }
    }

    /**
     * Start of Methods from the puzzle interface
     */

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
        //this.transform.parent.position = Vector3.Lerp(this.transform.parent.position, openDoorPosition, 0.6f * Time.deltaTime);
        this.gameObject.tag = "Untagged";
        minuteHand.GetComponent<Renderer>().material = correctMaterial;
        hourHand.GetComponent<Renderer>().material = correctMaterial;
        rotateMinute = false;
        minuteHandCorrect = true;
        hourHandCorrect = true;
        ShaderManager.Instance.LerpFloatProperty(this.gameObject.GetComponent<Renderer>().material, "_DisolveValue", 1.5f);
        ShaderManager.Instance.LerpOpacityProperty(minuteHand.GetComponent<Renderer>().material, "_BaseColor", 0f);
        ShaderManager.Instance.LerpOpacityProperty(hourHand.GetComponent<Renderer>().material, "_BaseColor", 0f);
        if (DatabaseManager.Instance.CurrentState.level == GetLevel() && DatabaseManager.Instance.CurrentState.part == GetPart())
        {
            DatabaseManager.Instance.UpdateState("1", "2");
        }

        if (this.gameObject.GetComponent<Renderer>().material.GetFloat("_DisolveValue") > 1.4f){
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            DestroyImmediate(hourHand);
            DestroyImmediate(minuteHand);
            DestroyImmediate(this);
        }
    }

    public Vector3 GetSpawnPosition()
    {
        return new Vector3(0f, 0.01f, 10.53f);
    }

    public Vector3 GetSpawnRotation()
    {
        return new Vector3(0f, -179.99f, 0f);
    }

    /**
    * End of Methods from the puzzle interface
    */
}
