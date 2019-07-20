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

public class DatabaseManager
{
    private FirebaseAuth firebaseAuth;
    DatabaseReference reference;
    public StateModel CurrentState { get; set; }

    private static readonly DatabaseManager instance = new DatabaseManager();

    static DatabaseManager()
    {
    }

    private DatabaseManager()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dimension-code.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public static DatabaseManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void readData()
    {
        reference.Child("users").Child(firebaseAuth.CurrentUser.UserId)
       .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        CurrentState = JsonToObject(args.Snapshot.GetRawJsonValue());
    }

    public async Task<DataSnapshot> ReadState()
    {
        return await reference.Child("users").Child(firebaseAuth.CurrentUser.UserId).GetValueAsync();

    }

    public void UpdateState(string level, string part)
    {     
        StateModel currentState = new StateModel(firebaseAuth.CurrentUser.Email, level, part);
        Debug.Log("Update Data: " + JsonUtility.ToJson(currentState));
        reference.Child("users").Child(firebaseAuth.CurrentUser.UserId).SetRawJsonValueAsync(JsonUtility.ToJson(currentState));
    }

    public StateModel JsonToObject(string jsonString)
    {
        return JsonUtility.FromJson<StateModel>(jsonString);
    }
}
