using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;
using System.Threading.Tasks;

public class DatabaseManager : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField mainInputField;
    private FirebaseAuth firebaseAuth;
    DatabaseReference reference;


    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dimension-code.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        // readData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void readData()
    {
        FirebaseDatabase.DefaultInstance
       .GetReference("users")
       .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        Debug.Log(args.Snapshot.GetValue(true));
        text.text = (string)args.Snapshot.GetValue(true);
    }

    public async Task<DataSnapshot> ReadState()
    {
        return await reference.Child("users").Child(firebaseAuth.CurrentUser.UserId).GetValueAsync();

    }

    public void UpdateState(StateModel currentState)
    {
        Debug.Log("Update Data: " + JsonUtility.ToJson(currentState));
        reference.Child("users").Child(firebaseAuth.CurrentUser.UserId).SetRawJsonValueAsync(JsonUtility.ToJson(currentState));
    }

    public StateModel JsonToObject(string jsonString)
    {
        return JsonUtility.FromJson<StateModel>(jsonString);
    }
}
