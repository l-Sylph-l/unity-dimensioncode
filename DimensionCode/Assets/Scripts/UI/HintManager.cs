using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HintsCollection
{
    public List<HintModel> hints;
}

public class HintManager : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text hintText;
    public Image panelBackground;
    public AudioSource uiSound;
    private int textPerFrame = 1;
    private string fileName = "hints.json";
    private HintsCollection hintsContainer;
    private StateModel currentState;
    private string currentText = "";
    private int currentTextIndex = 0;
    private bool writeNewText = false;
    private bool showHint = false;
    private float timeUntilHintDisplay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        currentState = DatabaseManager.Instance.CurrentState;
        LoadHints();
        currentText = hintsContainer.hints[0].hintText;
        ChangeColor(new Color32(0, 0, 255, 246));
    }

    private void Update()
    {
        HandleVisibility();
        UpdateColor();
        CheckCurrentHint();

        if (writeNewText && timeUntilHintDisplay < -0.2f )
        {
            ChangeText();
        }
        else
        {
            CheckIfTextHasChanged();
        }
    }

    private void LoadHints()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            hintsContainer = JsonUtility.FromJson<HintsCollection>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load hints!");
        }
    }

    public string GetHint(string key)
    {
        foreach (HintModel hint in hintsContainer.hints)
        {
            if (hint.hintName == key)
            {
                return hint.hintText;
            }
        }

        return "NO TEXT FOUND!";
    }

    private void ShowHint()
    {
        if (hintText.color.a < 1f)
        {  
            Color currentTextColor = hintText.color;
            Color currentPanelColor = panelBackground.color;
            float textAlphaValue = Mathf.Clamp(currentPanelColor.a + Time.deltaTime, 0f, 1f);
            float panelAlphaValue = Mathf.Clamp(currentPanelColor.a + Time.deltaTime, 0f, 0.95f);
            currentTextColor.a = textAlphaValue;
            currentPanelColor.a = panelAlphaValue;
            hintText.color = currentTextColor;
            panelBackground.color = currentPanelColor;
        }
    }

    private void HideHint()
    {
        if (hintText.color.a > 0f)
        {
        Color currentTextColor = hintText.color;
        Color currentPanelColor = panelBackground.color;
        float textAlphaValue = Mathf.Clamp(currentPanelColor.a - Time.deltaTime, 0f, 1f);
        float panelAlphaValue = Mathf.Clamp(currentPanelColor.a - Time.deltaTime, 0f, 0.95f);
        currentTextColor.a = textAlphaValue;
        currentPanelColor.a = panelAlphaValue;
        hintText.color = currentTextColor;
        panelBackground.color = currentPanelColor;
        } 
    }

    private void HandleVisibility()
    {

        if (timeUntilHintDisplay < 0f)
        {
            ShowHint();
        }
        else
        {
            HideHint();
        }

        timeUntilHintDisplay -= Time.deltaTime;
    }

    private void ChangeColor(Color32 color)
    {
        Color panelColor = color;
        panelColor.a = 0f;
        hintText.fontSharedMaterial.SetColor("_UnderlayColor", color);
        hintText.UpdateMeshPadding();
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
        if (currentText != hintText.text)
        {
            writeNewText = true;
            hintText.text = "";
        }
    }

    private void ChangeText()
    {
        if (writeNewText)
        {
            if (!uiSound.isPlaying){
                uiSound.Play();
            }

            hintText.text += currentText.Substring(currentTextIndex, textPerFrame);
            currentTextIndex += textPerFrame;

            if (currentTextIndex == currentText.Length)
            {
                writeNewText = false;
                currentTextIndex = 0;
                uiSound.Stop();
            }
        }
    }

    private void CheckCurrentHint()
    {
        if (currentState.part != DatabaseManager.Instance.CurrentState.part)
        {
            currentState.part = DatabaseManager.Instance.CurrentState.part;
            timeUntilHintDisplay = 10f;
        }

        if (currentState.part == "1" && currentState.level == "1")
        {
            currentText = GetHint("ClockPuzzleHint");
        }

        if (currentState.part == "2" && currentState.level == "1")
        {
            currentText = GetHint("ButtonPuzzleHint");
        }

        if (currentState.part == "3" && currentState.level == "1")
        {
            currentText = GetHint("ElevatorPuzzleHint");
        }

        if (currentState.part == "4" && currentState.level == "1")
        {
            currentText = GetHint("LevelSwitchPuzzleHint");
        }
    }
}


