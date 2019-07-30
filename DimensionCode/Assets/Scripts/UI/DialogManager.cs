using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text dialogText;
    public Image panelBackground;
    public AudioSource uiSound;
    private bool showDialog = false;
    private int textPerFrame = 1;
    private string currentText = "";
    private int currentTextIndex = 0;
    private bool writeNewText = false;
    private StateModel currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = DatabaseManager.Instance.CurrentState;
        dialogText.text = currentText;
    }

    private void Update()
    {
        UpdateColor();
        HandleVisibility();

        if (writeNewText)
        {
            ChangeText();
        }
        else
        {
            CheckIfTextHasChanged();
        }
    }

    private void ShowDialog()
    {
        if (dialogText.color.a < 1f)
        {
            Color currentTextColor = dialogText.color;
            Color currentPanelColor = panelBackground.color;
            float textAlphaValue = Mathf.Clamp(currentPanelColor.a + Time.deltaTime, 0f, 1f);
            float panelAlphaValue = Mathf.Clamp(currentPanelColor.a + Time.deltaTime, 0f, 0.95f);
            currentTextColor.a = textAlphaValue;
            currentPanelColor.a = panelAlphaValue;
            dialogText.color = currentTextColor;
            panelBackground.color = currentPanelColor;
        }
    }

    private void HideDialog()
    {
        if (dialogText.color.a > 0f)
        {
            Color currentTextColor = dialogText.color;
            Color currentPanelColor = panelBackground.color;
            float textAlphaValue = Mathf.Clamp(currentPanelColor.a - Time.deltaTime, 0f, 1f);
            float panelAlphaValue = Mathf.Clamp(currentPanelColor.a - Time.deltaTime, 0f, 0.95f);
            currentTextColor.a = textAlphaValue;
            currentPanelColor.a = panelAlphaValue;
            dialogText.color = currentTextColor;
            panelBackground.color = currentPanelColor;
        }
    }

    private void HandleVisibility()
    {
        if (showDialog)
        {
            ShowDialog();
        }
        else
        {
            HideDialog();
        }
    }

    private void ChangeColor(Color color)
    {
        dialogText.fontSharedMaterial.SetColor("_UnderlayColor", color);
        dialogText.UpdateMeshPadding();
        panelBackground.color = color;
    }

    private void UpdateColor()
    {
        if (DatabaseManager.Instance.CurrentState.level == "1")
        {
            ChangeColor(new Color(0f, 0f, 1f, panelBackground.color.a));
        }

        if (DatabaseManager.Instance.CurrentState.level == "2")
        {
            ChangeColor(new Color(0f, 1f, 0f, panelBackground.color.a));
        }

        if (DatabaseManager.Instance.CurrentState.level == "3")
        {
            ChangeColor(new Color(1f, 0f, 0f, panelBackground.color.a));
        }
    }

    private void CheckIfTextHasChanged()
    {
        if (currentText != dialogText.text)
        {
            writeNewText = true;
            dialogText.text = "";
        }
    }

    private void ChangeText()
    {
        if (writeNewText)
        {
            if (!uiSound.isPlaying)
            {
                uiSound.Play();
            }

            dialogText.text += currentText.Substring(currentTextIndex, textPerFrame);
            currentTextIndex += textPerFrame;

            if (currentTextIndex == currentText.Length)
            {
                writeNewText = false;
                currentTextIndex = 0;
                uiSound.Stop();
            }
        }
    }

    public void ActivateDialog(string textToShow)
    {
        currentText = textToShow;
        showDialog = true;
    }

    public void DeactivateDialog()
    {
        //currentText = "";
        showDialog = false;
    }
}
