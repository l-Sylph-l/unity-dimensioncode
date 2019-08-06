using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class Terminal : MonoBehaviour, InteractableInterface
{
    public GameObject prison;
    [SerializeField]
    private GameObject TerminalUi;
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private GameObject Access_denied;
    [SerializeField]
    private GameObject Access_granted;
    private bool corredWord = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfEscapePressed();
        CheckIfEnterPressed();
        DestroyPrison();
    }

    public void Interact()
    {
        TerminalUi.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();       
    }

    private void CheckIfEscapePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TerminalUi.SetActive(false);
        }
    }

    private void CheckIfEnterPressed()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !Access_granted.activeSelf)
        {
            if (inputField.text.ToLower() == "africa")
            {
                Access_denied.SetActive(false);
                Access_granted.SetActive(true);
                inputField.DeactivateInputField();
                corredWord = true;
            }
            else
            {
                Access_denied.SetActive(true);
            }
        }
    }

    private void DestroyPrison()
    {
        if (corredWord == true)
        {
            Destroy(prison);
            inputField.text = "africa";
        }
    }

}
