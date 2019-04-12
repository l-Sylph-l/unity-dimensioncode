using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public float rotationSpeedHour;
    public float rotationSpeedMinute;
    private bool rotateHour = true;
    private bool rotateMinute = true;

    // Start is called before the first frame update
    void Start()
    {
 
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

    private int convertToHour(float angle)
    {
        float result = angle / 30f;

        return (int)result;
    }

    private int convertToMinute(float angle)
    {
        float result = angle / 6f;

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
        Debug.Log(DateTime.Now.Minute);
        int currentHour = DateTime.Now.Hour;

        if (currentHour > 12)
        {
            currentHour = currentHour - 12;
        }

        if(convertToHour(hourHand.transform.eulerAngles.y) != currentHour)
        {
            rotateHour = true;
        }
    }
}
