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
        HandleVisibility();
        UpdateColor();

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

    private void ChangeColor(Color32 color)
    {
        Color panelColor = color;
        panelColor.a = 0f;
        dialogText.fontSharedMaterial.SetColor("_UnderlayColor", color);
        dialogText.UpdateMeshPadding();
        panelBackground.color = panelColor;
    }

    private void UpdateColor()
    {
        if (currentState.level != DatabaseManager.Instance.CurrentState.level)
        {
            currentState = DatabaseManager.Instance.CurrentState;

            Color32 currentColor = new Color32(0, 0, 255, 246);

            if (DatabaseManager.Instance.CurrentState.level == "2")
            {
                currentColor = new Color32(0, 255, 0, 246);
            }

            if (DatabaseManager.Instance.CurrentState.level == "3")
            {
                currentColor = new Color32(255, 0, 0, 246);
            }

            ChangeColor(currentColor);

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
