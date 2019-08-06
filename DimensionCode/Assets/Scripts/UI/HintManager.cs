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
    [SerializeField]
    private PrologueManager prologueManager;
    public DialogManager dialogManager;
    private string fileName = "hints.json";
    private HintsCollection hintsContainer;
    private StateModel currentState;
    private string currentText = "";
    private float timeUntilHintDisplay = 10f;
    private bool stopShowingHints = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = DatabaseManager.Instance.CurrentState;
        LoadHints();
    }

    private void Update()
    {
        if (prologueManager.CheckIfPrologueFinished() && !stopShowingHints)
        {
            CheckCurrentHint();
            HandleHintActivation();
        }
    }

    public void StopShowingHints()
    {
        stopShowingHints = true;
        dialogManager.DeactivateDialog();
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

    private void HandleHintActivation()
    {

        if (timeUntilHintDisplay < 0f)
        {
            dialogManager.ActivateDialog(currentText);
        }
        else
        {
            dialogManager.DeactivateDialog();
        }

        if (currentText != "")
        {
            timeUntilHintDisplay -= Time.deltaTime;
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

        if (currentState.part == "1" && currentState.level == "2")
        {
            currentText = GetHint("DoorPuzzleHint");
        }

        if (currentState.part == "2" && currentState.level == "2")
        {
            currentText = GetHint("TetrisPuzzleHint");
        }

        if (currentState.part == "3" && currentState.level == "2")
        {
            currentText = GetHint("LevelTwoSwitchPuzzleHint");
        }

        if (currentState.part == "1" && currentState.level == "3")
        {
            currentText = GetHint("SplitterPuzzle");
        }

        if (currentState.part == "2" && currentState.level == "3")
        {
            currentText = GetHint("TerminalPuzzle");
        }
    }
}


