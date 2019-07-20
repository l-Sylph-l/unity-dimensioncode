using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DatabaseManager.Instance.readData();
    }
}
