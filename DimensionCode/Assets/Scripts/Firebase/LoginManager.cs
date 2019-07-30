using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Database;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private FirebaseAuth firebaseAuth;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_Text successMessage;
    public TMP_Text errorMessage;
    public GameObject successPopup;
    public GameObject errorPopup;
    public Image fadeInEffect;
    private string errorMessageValue = "";
    private bool loginButtonClicked = false;
    private bool loadScene = false;

    // Start is called before the first frame update
    void Start()
    {
        firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        email.text = PlayerPrefs.GetString("email");
        password.text = PlayerPrefs.GetString("password");
        successPopup.SetActive(false);
        errorPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (firebaseAuth.CurrentUser != null)
        {
            loginButtonClicked = false;
            successPopup.SetActive(true);
            successMessage.text = "Signed in successfully";
            successMessage.color = new Color32(0, 255, 0, 255);
        }
        else if (loginButtonClicked)
        {
            loginButtonClicked = false;
            errorPopup.SetActive(true);
            errorMessage.text = errorMessageValue;
            errorMessage.color = new Color32(255, 0, 0, 255);
        }

        if (loadScene)
        {
            FadeIn();
        }
    }

    public void DoLogin()
    {
        PlayerPrefs.SetString("email", email.text);
        PlayerPrefs.SetString("password", password.text);

        firebaseAuth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(async task =>
        {
            loginButtonClicked = true;
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                errorMessageValue = "Login process was canceled.";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                errorMessageValue = "An error encountered";
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            string result = "";
            await DatabaseManager.Instance.ReadState().ContinueWith(dbTask =>
            {
                if (dbTask.IsFaulted)
                {
                    // Handle the error...
                }
                else if (dbTask.IsCompleted)
                {
                    DataSnapshot snapshot = dbTask.Result;
                    result = snapshot.GetRawJsonValue();
                    DatabaseManager.Instance.readData();
                    if (result == null || result == "")
                    {
                        DatabaseManager.Instance.UpdateState("1", "1");
                    }

                }
            });
        });
    }

    public void ContinueGame()
    {
        loadScene = true;
    }

    public void StartNewGame()
    {
        DatabaseManager.Instance.UpdateState("1", "1");
        loadScene = true;
    }

    public void DeactivateErrorPopup()
    {
        errorPopup.SetActive(false);
    }

    private void FadeIn()
    {
        Color currentColor = fadeInEffect.color;
        currentColor.a += Time.deltaTime;
        Mathf.Clamp(currentColor.a, 0f, 255f);
        fadeInEffect.color = currentColor;

        if (currentColor.a >= 1f)
        {
            SceneManager.LoadScene("PrototypeLevel");
        }

    }
}
