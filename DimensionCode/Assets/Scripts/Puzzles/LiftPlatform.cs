using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LiftPlatform : MonoBehaviour
{
    [Range(0f, 1f), SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
    private float maxHeight = 12f;
    private Vector3 startPosition;
    private float secondCounter = 0f;
    private float speedBuffer;
    public float endHeight = 10.04f;
    private float stopHeight = 6.5f;

    public bool MoveToStopPosition { get; set; } = false;
    public bool MoveToEndPosition { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        speedBuffer = speed;
    }

    // Update is called once per frame
    void Update()
    {
        RespawnPlatform();
        MovePlatform();
    }

    private void MovePlatform()
    {
        //this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        Vector3 targetPosition = new Vector3(this.transform.position.x, maxHeight, this.transform.position.z);
        if (MoveToStopPosition)
        {
            targetPosition = new Vector3(this.transform.position.x, stopHeight, this.transform.position.z);
        }
        else if (MoveToEndPosition)
        {
            targetPosition = new Vector3(this.transform.position.x, endHeight, this.transform.position.z);
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * speed * 4f);
        secondCounter += Time.deltaTime;
    }

    public void ChangeSpeed(ButtonFunction buttonFunction)
    {
        if (!MoveToEndPosition && !MoveToStopPosition)
        {
            switch (Speed)
            {
                case 1f:
                    if (ButtonFunction.Slower == buttonFunction)
                    {
                        Debug.Log("Button clicked, Speed: " + speed);
                        speedBuffer = 0.9f;
                    }
                    else
                    {
                        speedBuffer = 1f;
                    }
                    break;
                case 0.9f:
                    if (ButtonFunction.Slower == buttonFunction)
                    {
                        Debug.Log("Button clicked, Speed: " + speed);
                        speedBuffer = 0.8f;
                    }
                    else
                    {
                        speedBuffer = 1f;
                    }
                    break;
                case 0.8f:
                    if (ButtonFunction.Slower == buttonFunction)
                    {
                        Debug.Log("Button clicked, Speed: " + speed);
                        speedBuffer = 0.7f;
                    }
                    else
                    {
                        speedBuffer = 0.9f;
                    }
                    break;
                case 0.7f:
                    if (ButtonFunction.Slower == buttonFunction)
                    {
                        Debug.Log("Button clicked, Speed: " + speed);
                        speedBuffer = 0.7f;
                    }
                    else
                    {
                        speedBuffer = 0.8f;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void RespawnPlatform()
    {
        if (secondCounter > 8f && !MoveToEndPosition && !MoveToStopPosition)
        {
            Debug.Log("Lift Time: " + secondCounter + ", Speed: " + speed);
            secondCounter = 0f;
            this.transform.position = startPosition;
            speed = speedBuffer;
        }
    }
}
