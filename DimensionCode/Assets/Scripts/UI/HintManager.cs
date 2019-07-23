using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class HintsCollection
{
    public HintModel[] hints;
}

public class HintManager : MonoBehaviour
{
    public TMP_Text hintText;
    private string currentText = "";
    private string fileName = "hints.json";
    private HintsCollection hintsContainer;

    // Start is called before the first frame update
    void Start()
    {
        LoadHints();
        Debug.Log(hintsContainer.hints[0].HintName);
        hintText.text = hintsContainer.hints[0].HintText;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
