using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    public List<GameObject> lockList;
    public List<float> lockRotationList;
    private List<GameObject> lockListCopy;
    private List<float> lockRotationListCopy;

    // Start is called before the first frame update
    void Start()
    {
        lockListCopy = new List<GameObject>(lockList);
        lockRotationListCopy = new List<float>(lockRotationList);
    }

    // Update is called once per frame
    void Update()
    {
        RotateLocks();

        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    private void RotateLocks()
    {
        if(lockListCopy.Count == 0)
        {
            lockListCopy = new List<GameObject>(lockList);
            lockRotationListCopy = new List<float>(lockRotationList);
        }

        int index = 0;
        foreach (GameObject element in lockListCopy)
        {
            float rotationSpeed = lockRotationList[index] * Time.deltaTime;
            element.transform.Rotate(0, rotationSpeed, 0);
            index++; 
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
            Debug.Log(hit.transform.name);
            Transform currentClockHand = hit.transform;

            int index = 0;

            foreach (GameObject element in lockListCopy)
            {
                if (currentClockHand == element.transform)
                {
                    index = lockListCopy.IndexOf(element);
                }
            }

            lockListCopy.RemoveAt(index);
            lockRotationListCopy.RemoveAt(index);
        }
    }
}
