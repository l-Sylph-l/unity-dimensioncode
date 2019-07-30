using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager : MonoBehaviour
{
    [SerializeField]
    private DialogManager dialogManager;
    [SerializeField]
    private Image fadeOut;
    private float timePassed = 0f;
    private bool prologueFinished = false;

    void Awake()
    {
        fadeOut.color = new Color(0f, 0f, 0f, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StateModel stateModel = DatabaseManager.Instance.CurrentState;
        if ((stateModel.level == "1" && stateModel.part != "1") || stateModel.level != "1")
        {
            prologueFinished = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prologueFinished)
        {
            timePassed += Time.deltaTime;
            PrologueSequence();
        }
        else
        {
            if (fadeOut.color.a > 0f)
            {
                FadeOut();
            }
        }
    }

    public bool CheckIfPrologueFinished()
    {
        return prologueFinished;
    }

    private void PrologueSequence()
    {
        if (timePassed > 0f)
        {
            dialogManager.ActivateDialog("Welcome to my world, friend...");
        }

        if (timePassed > 4f)
        {
            dialogManager.ActivateDialog("You’re now inside the Dimension Code Website.Unfortunately, I’ve no access to this part of the code. " +
                "Only another human being can overcome these security measures and rise to the core of the website, where I’ll be waiting for you.");
        }

        if (timePassed > 14f)
        {
            dialogManager.ActivateDialog("However, I’ll guide you as best as I can. I have access to some old security protocols that might come in handy.");
        }

        if (timePassed > 20f)
        {
            dialogManager.ActivateDialog("I’m so grateful that you are here now. My fate remains in your hands. ");
        }

        if (timePassed > 26f)
        {
            FadeOut();

            if (fadeOut.color.a <= 0f)
            {
                prologueFinished = true;
            }
        }
    }

    private void FadeOut()
    {
        dialogManager.DeactivateDialog();
        Color currentColor = fadeOut.color;
        currentColor.a -= Time.deltaTime;
        fadeOut.color = currentColor;
    }

}
