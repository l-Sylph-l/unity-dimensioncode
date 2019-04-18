using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public Material correctMaterial;
    public Material failMaterial;
    public float rotationSpeedHour;
    public float rotationSpeedMinute;
    private bool rotateHour = true;
    private bool rotateMinute = true;
    private Material initialHourMaterial;
    private Material initialMinuteMaterial;

    // Start is called before the first frame update
    void Start()
    {
        initialHourMaterial = hourHand.GetComponent<Renderer>().material;
        initialMinuteMaterial = minuteHand.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        RotateHands();

        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }

        if (!rotateHour && !rotateMinute)
        {

            CheckTime();
        }
    }

    private void RotateHands()
    {
        if (rotateHour)
        {
            hourHand.transform.Rotate(0, rotationSpeedHour * Time.deltaTime, 0);
        }

        if (rotateMinute)
        {
            minuteHand.transform.Rotate(0, rotationSpeedMinute * Time.deltaTime, 0);
        }
    }

    private int GetCurrentHourToHour()
    {
        float result = hourHand.transform.eulerAngles.y / 30f;

        if(result == 0)
        {
            result = 12;
        }

        return (int)result;
    }

    private int GetCurrentMinute()
    {
        float result = minuteHand.transform.eulerAngles.y / 6f;

        return (int)result;
    }

    void ShootRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform currentClockHand = hit.transform;

            if (currentClockHand == hourHand.transform)
            {
                rotateHour = false;
            }

            if (currentClockHand == minuteHand.transform)
            {
                rotateMinute = false;
            }
        }
    }

    private void CheckTime()
    {
        Debug.Log(DateTime.Now.Hour);
        Debug.Log(GetCurrentHourToHour());
        Debug.Log(DateTime.Now.Minute);
        Debug.Log(GetCurrentMinute());
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;

        if (currentHour > 12)
        {
            currentHour = currentHour - 12;
        }

        if (GetCurrentHourToHour() != currentHour)
        {
            rotateHour = true;
            hourHand.GetComponent<Renderer>().material = failMaterial;
        } else
        {
            hourHand.GetComponent<Renderer>().material = correctMaterial;
        }

        if (GetCurrentMinute() != currentMinute)
        {
            rotateMinute= true;
            minuteHand.GetComponent<Renderer>().material = failMaterial;
        }
        else
        {
            minuteHand.GetComponent<Renderer>().material = correctMaterial;
        }
    }

}
