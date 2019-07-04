using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{
    private FirebaseAuth firebaseAuth;
    public TMP_InputField phoneNumber;
    public TMP_Text idText;
    public TMP_Text tokenText;

    // Start is called before the first frame update
    void Start()
    {
        firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoLogin()
    {
        firebaseAuth.SignInWithEmailAndPasswordAsync("c.stefano6@gmail.com", "123456").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });




        //Debug.Log($"Started Login Process with phonenumber '{phoneNumber.text}'");
        //Debug.Log("Started Login Process");
        //PhoneAuthProvider provider = PhoneAuthProvider.GetInstance(firebaseAuth);
        //provider.VerifyPhoneNumber(phoneNumber.text, 5000, null,
        //  verificationCompleted: (credential) => {
        //      Debug.Log("verificationCompleted");

        //      // Auto-sms-retrieval or instant validation has succeeded (Android only).
        //      // There is no need to input the verification code.
        //      // `credential` can be used instead of calling GetCredential().
        //  },
        //  verificationFailed: (error) => {
        //      Debug.Log("error");
        //      // The verification code was not sent.
        //      // `error` contains a human readable explanation of the problem.
        //  },
        //  codeSent: (id, token) => {

        //      Debug.Log("codeSent");
        //      Debug.Log("Id: " + id);
        //      Debug.Log("Token: " + token);

        //      idText.text = id;


        //      // Verification code was successfully sent via SMS.
        //      // `id` contains the verification id that will need to passed in with
        //      // the code from the user when calling GetCredential().
        //      // `token` can be used if the user requests the code be sent again, to
        //      // tie the two requests together.
        //  },
        //  codeAutoRetrievalTimeOut: (id) => {
        //      Debug.Log("codeAutoRetrievalTimeOut");
        //      Debug.Log("Id: " + id);
        //      // Called when the auto-sms-retrieval has timed out, based on the given
        //      // timeout parameter.
        //      // `id` contains the verification id of the request that timed out.
        //  });

    }
}
