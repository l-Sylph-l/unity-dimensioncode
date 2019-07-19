using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisTrigger : MonoBehaviour
{
    private List<GameObject> triggerlist = new List<GameObject>();

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "InteractableChild")
        {
            triggerlist.Add(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "InteractableChild")
        {
            triggerlist.Remove(col.gameObject);
        }
    }

    public int getCount ()
    {
        return triggerlist.Count;
    }
}
